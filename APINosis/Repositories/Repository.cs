
using APINosis.Entities;
using APINosis.Helpers;
using APINosis.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Repositories
{
    public class Repository
    {

        public ApiNosisContext Context { get; }
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        public Repository(ApiNosisContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            Context = context;
            Configuration = configuration;
            Logger = logger;
        }


        public TResponse MapToValue<TResponse>(SqlDataReader reader)
        {
            var respuesta = (TResponse)Activator.CreateInstance(typeof(TResponse), new object[] { });
            Type typeResponse = typeof(TResponse);
            System.Reflection.PropertyInfo[] listaPropiedades = typeResponse.GetProperties();

            for (int i = 0; i < listaPropiedades.Count(); i++)
            {
                if (reader.GetColumnSchema().Any(c => c.ColumnName == listaPropiedades[i].Name))
                {
                    if (reader[listaPropiedades[i].Name] != DBNull.Value)
                    {

                        if (listaPropiedades[i].PropertyType == typeof(string))
                        {
                            listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name].ToString());
                        }
                        else
                        {
                            if (listaPropiedades[i].PropertyType == typeof(bool))
                            {
                                listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name].ToString() == "S" ? true : false);
                            }
                            else
                            {
                                if (listaPropiedades[i].PropertyType == typeof(decimal))
                                {
                                    listaPropiedades[i].SetValue(respuesta, (decimal)reader[listaPropiedades[i].Name]);
                                }
                                else
                                {
                                    listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name]);
                                }
                            }
                        }

                    }
                }

            }

            return respuesta;
        }

        public async Task<IEnumerable<TResult>> ExecuteStoredProcedure<TResult>(string sqlCommand, Dictionary<string, object> parameters)
        {
            List<TResult> result = new List<TResult>();

            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand(sqlCommand, sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                    }

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(MapToValue<TResult>(reader));
                        }
                    }
                }
            }

            return result;

        }



        public async Task<string> ExecuteSqlInsertToTablaSAR(string query)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        await InsertaCwJmSchedules("API");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            return $"Error al generar registracion. El id de operacion ya existe.";
                        }
                        else
                        {
                            return ex.Message;
                        }

                    }
                }

                return "";
            }
        }

        private async Task InsertaCwJmSchedules(string codjob)
        {
            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand("ALM_InsCwJmSchedules", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CODJOB", codjob));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    //Logger.Information("Se insertó cwjmschedules");
                }
            }
        }



        protected string ArmoQueryInsertTablaSAR(List<KeyValuePair<string, object>> fieldsValues, string tableDestination, string previousQuery = "")
        {
            string query = previousQuery + "INSERT INTO [dbo].[" + tableDestination + "] (";

            foreach (var item in fieldsValues)
            {
                query = query + item.Key + ",";
            }

            query = query.Remove(query.Length - 1, 1) + ") VALUES (";

            foreach (var item in fieldsValues)
            {
                query = query + item.Value + ",";
            }
            query = query.Remove(query.Length - 1, 1) + ")";

            return query;


        }

        protected async Task<Transaccion> GetTransaccion(string idOperacion, string table)
        {
            string query = $"SELECT * FROM {table} WHERE {table}_IDENTI = '{idOperacion}'";

            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    try
                    {
                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                {
                                    switch ((string)reader[$"{table}_STATUS"])
                                    {
                                        case "E":
                                            return new Transaccion(idOperacion, (string)reader[$"{table}_STATUS"], "Procesado con error",(string)reader[$"{table}_ERRMSG"]);

                                        case "S":
                                            return new Transaccion(idOperacion, (string)reader[$"{table}_STATUS"], "Procesado con exito", "");

                                        case "N":
                                            return new Transaccion(idOperacion, (string)reader[$"{table}_STATUS"], "Pendiente de procesar.","");

                                        case "P":
                                            return new Transaccion(idOperacion, (string)reader[$"{table}_STATUS"], "En procesamiento.","");

                                        default:
                                            break;
                                    }

                                }
                            }
                            else
                            {
                                throw new NotFoundException($"El id de operación {idOperacion} no existe.");
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new BadRequestException($"Error al consultar el id de operacion");
                    }

                    return new Transaccion(idOperacion.ToString(), "", "","");
                }


            }
        }

    }
}
