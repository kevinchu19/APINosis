using ApiNosis.Models;
using APINosis.Entities;
using APINosis.Helpers;
using APINosis.Interfaces;
using APINosis.Models;
using APINosis.Models.Response;
using APINosis.OE;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace APINosis.Repositories
{
    public class FacturasRepository: Repository
    {
        
        public FC_RR_FCRMVH oFcrmvh { get; set; }

        public FacturasRepository(ApiNosisContext context, Serilog.ILogger logger,IConfiguration configuration) :
            base(context, configuration, logger)
        {
            //oFcrmvh = oInstanceFCRMVH;
        }


        public async Task<FacturaResponse> GraboFacturaSQL(FacturasDTO factura)
        {
            InsertSqlHelpers sqlHelp = new InsertSqlHelpers(Configuration);

            Vtmclh cliente = await Context.Vtmclh.Where(c => c.VtmclhNrocta == factura.Cliente).FirstOrDefaultAsync();
            if (cliente == null)
            {
                return new FacturaResponse("Bad Request", 0, $"El cliente {factura.Cliente} no existe.");
            }

            List<KeyValuePair<string, object>> mapeoCampos = sqlHelp.CreateDictionarySAR_FCRMVH(factura, factura.IdOperacion).ToList();

            string query = "BEGIN TRAN ";
            query += ArmoQueryInsertTablaSAR(mapeoCampos.Where(k => k.Value is not IEnumerable<object>).ToList(), "SAR_FCRMVH");
            
            foreach (KeyValuePair<string, object> tablaHija in mapeoCampos.Where(k => k.Value is IEnumerable<object>).ToList())
            {
                int index = 0;
                foreach (var item in (IEnumerable<object>)tablaHija.Value)
                {
                    index++;
                    switch (tablaHija.Key)
                    {
                        case "SAR_FCRMVI":
                            mapeoCampos = sqlHelp.CreateDictionarySAR_FCRMVI((FacturasItemsDTO)item, factura.IdOperacion, index).ToList();
                            query = ArmoQueryInsertTablaSAR(mapeoCampos, tablaHija.Key, query);
                            break;
                        case "SAR_FCRMVI07":
                            mapeoCampos = sqlHelp.CreateDictionarySAR_FCRMVI07((ImpuestosFacturasDTO)item, factura.IdOperacion, index).ToList();
                            query = ArmoQueryInsertTablaSAR(mapeoCampos, tablaHija.Key, query);
                            break;
                        default:
                            break;
                    }
                }

            }


            query += " COMMIT TRAN ";

            string errorMessage = await ExecuteSqlInsertToTablaSAR(query);


            return errorMessage != "" ? new FacturaResponse("Bad Request", factura.IdOperacion, errorMessage) :
                                        new FacturaResponse("OK", factura.IdOperacion, null, "Petición procesada");


        }


        public async Task<FacturaResponse> GraboFacturaSoftland(Fcrmvh factura, string tipoOperacion)
        {

            Vtmclh cliente = await Context.Vtmclh.Where(c=>c.VtmclhNrocta == factura.Fcrmvh_Nrocta).FirstOrDefaultAsync();
            if (cliente==null)
            {
                return new FacturaResponse("Bad Request", 0, $"El cliente {factura.Fcrmvh_Nrocta} no existe.");
            }

            oFcrmvh = new FC_RR_FCRMVH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]);

            oFcrmvh.instancioObjeto(tipoOperacion);

            oFcrmvh.asignoaTMWizard("VIRT_CIRCOM", factura.Virt_Circom, Logger);
            oFcrmvh.asignoaTMWizard("VIRT_CIRAPL", factura.Virt_Cirapl, Logger);
            oFcrmvh.asignoaTMWizard("VIRT_CODCVT", factura.Virt_Codcvt, Logger);

            oFcrmvh.MoveNext();

            Type typeFactura = factura.GetType();

            IEnumerable<PropertyInfo> listaPropiedades = typeFactura.GetProperties()
                                                            .Where(e => e.Name != "Virt_Circom" &&
                                                                        e.Name != "Virt_Cirapl" && 
                                                                        e.Name != "Virt_Codcvt");



            foreach (PropertyInfo propiedad in listaPropiedades)
            {
                if (propiedad.PropertyType != typeof(ICollection<Fcrmvi07>))
                { 
                    if (propiedad.PropertyType == typeof(ICollection<Fcrmvi>))
                    {

                        foreach (Fcrmvi item in factura.Items)
                        {
                            oFcrmvh.asignoaTM("FCRMVI", "", item, 2, Logger);
                        }
                    }
                    else
                    {
                        oFcrmvh.asignoaTM("FCRMVH", propiedad.Name, propiedad.GetValue(factura, null), 1, Logger);
                    }
                }


            }
            string mensajeError = oFcrmvh.completaImpuestos(factura.Impuestos);
            if (mensajeError != "")
            {
                return new FacturaResponse("Bad Request", 0, mensajeError);
            }

            Save PerformedOperation = oFcrmvh.save();

            //bool result = false;
            //string mensajeError = "Prueba sin grabar";
            bool result = PerformedOperation.Result;
            mensajeError = PerformedOperation.errorMessage;

            oFcrmvh.closeObjectInstance();

            if (result == false)
            {
                return new FacturaResponse("Bad Request", 0, mensajeError);
            }


            PerformedOperation.ComprobanteGenerado.Impuestos.AddRange(await RecuperoImpuestosComprobante(PerformedOperation.ComprobanteGenerado.ModuloComprobante,
                                                                                            PerformedOperation.ComprobanteGenerado.CodigoComprobante,
                                                                                          PerformedOperation.ComprobanteGenerado.NumeroComprobante));

            PerformedOperation.ComprobanteGenerado.ImporteTotal = await RecuperoTotalComprobante(PerformedOperation.ComprobanteGenerado.ModuloComprobante,
                                                                         PerformedOperation.ComprobanteGenerado.CodigoComprobante,
                                                                       PerformedOperation.ComprobanteGenerado.NumeroComprobante);

            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand("Alm_ActualizaImpuVTRMVI", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Modfor", PerformedOperation.ComprobanteGenerado.ModuloComprobante));
                    cmd.Parameters.Add(new SqlParameter("@Codfor", PerformedOperation.ComprobanteGenerado.CodigoComprobante));
                    cmd.Parameters.Add(new SqlParameter("@Nrofor", PerformedOperation.ComprobanteGenerado.NumeroComprobante));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }


            return new FacturaResponse("OK", 0, PerformedOperation.ComprobanteGenerado, "Comprobante generado");
        }

        public async Task<FacturasDTO> Get(string codigoComprobante, int? numeroComprobante, int? idOperacion)
        {
         
            List<FacturasDTO> facturas = new List<FacturasDTO>();

            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {

                facturas.AddRange( await ExecuteStoredProcedure<FacturasDTO>("ALM_FcrmvhGetForAPI",
                                                                            new Dictionary<string, object>{
                                                                                { "@Modfor", "VT"},
                                                                                { "@Codfor", codigoComprobante},
                                                                                { "@Nrofor", numeroComprobante},
                                                                                { "@IdCrm", idOperacion!=null?idOperacion:0}
                                                                            }));

                foreach (var item in facturas)
                {


                    item.Items.AddRange(await ExecuteStoredProcedure<FacturasItemsDTO>("ALM_FcrmviGetForAPI",
                                                                            new Dictionary<string, object>{
                                                                                    { "@Modfor", "VT"},
                                                                                    { "@Codfor", item.CodigoComprobante},
                                                                                    { "@Nrofor", item.NumeroComprobante}
                                                                            }));

                    item.ImpuestosFactura.AddRange(await ExecuteStoredProcedure<ImpuestosComprobanteGenerado>("ALM_VtrmvpGetForAPI",
                                                                           new Dictionary<string, object>{
                                                                                    { "@Modfor", "VT"},
                                                                                    { "@Codfor", item.CodigoComprobante},
                                                                                    { "@Nrofor", item.NumeroComprobante}
                                                                           }));
                }
            }

            return facturas.FirstOrDefault();

        }

        public async Task<Vtrmvh> RecuperoDatosCAE(string moduloComprobante, string codigoComprobante, int numeroComprobante)
        {
            Vtrmvh header = await Context.Vtrmvh
                        .Where(c => c.Vtrmvh_Modfor == moduloComprobante &&
                                    c.Vtrmvh_Codfor == codigoComprobante &&
                                    c.Vtrmvh_Nrofor == numeroComprobante).FirstOrDefaultAsync();
            return header;
        }

        public async Task<decimal?> RecuperoTotalComprobante(string moduloComprobante, string codigoComprobante, int numeroComprobante)
        {
            Vtrmvi total = await Context.Vtrmvi
                        .Where(c => c.Vtrmvi_Modfor == moduloComprobante &&
                                    c.Vtrmvi_Codfor == codigoComprobante &&
                                    c.Vtrmvi_Nrofor == numeroComprobante &&
                                    c.Vtrmvi_Tipcpt == "T").FirstOrDefaultAsync();
            return total.Vtrmvi_Impnac;
        }

        public async Task<IEnumerable<ImpuestosComprobanteGenerado>> RecuperoImpuestosComprobante(string moduloComprobante, string codigoComprobante, int numeroComprobante)
        {
            List<ImpuestosComprobanteGenerado> result = new List<ImpuestosComprobanteGenerado>();

            IEnumerable<Vtrmvp> impuestos = await Context.Vtrmvp
                        .Where(c => c.Vtrmvp_Modfor == moduloComprobante &&
                                    c.Vtrmvp_Codfor == codigoComprobante &&
                                    c.Vtrmvp_Nrofor == numeroComprobante).ToListAsync();
            foreach (Vtrmvp impuesto in impuestos)
            {
                result.Add(new ImpuestosComprobanteGenerado()
                {
                    TipoConcepto = impuesto.Vtrmvp_Tipcpt,
                    Concepto = impuesto.Vtrmvp_Codcpt,
                    ImporteGravado = impuesto.Vtrmvp_Impgra,
                    Tasa = impuesto.Vtrmvp_Porcen,
                    ImporteImpuesto = impuesto.Vtrmvp_Impues

                });

            }

            return result;
        }

        private async Task<string> GeneroCodigoPostal(string pais, string codpos, string jurisdiccion)
        {
            Grtpac codigoPostal = await Context.Grtpac
                                        .Where(c => c.GrtpacCodpai == pais && c.GrtpacCodpos == codpos)
                                        .FirstOrDefaultAsync();
            if (codigoPostal == null)
            {
                Grtpac newCodigoPostal = new Grtpac
                {
                    GrtpacCodpai = pais,
                    GrtpacCodpos = codpos,
                    GrtpacDescrp = "Generado Automáticamente",
                    GrtpacPaipro = pais,
                    GrtpacCodpro = "NA",
                    GrtpacFecalt = DateTime.Now,
                    GrtpacFecmod = DateTime.Now,
                    GrtpacUltopr = "A",
                    GrtpacOalias = "GRTPAC",
                    GrtpacDebaja = "N",
                    GrtpacUserid = "API-CRM"
                };
                await Context.Grtpac.AddAsync(newCodigoPostal);
                try
                {
                    await Context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return $"Error al generar codigo postal {newCodigoPostal.GrtpacCodpos}: {e.InnerException.Message}";
                }
            }

            return "";
        }

        public async Task<Transaccion> GetTransaccionById(string id)
        {

            Transaccion response = await GetTransaccion(id, "SAR_FCRMVH");
            if (response.StatusProcesamiento =="S")
            {
                response.ComprobanteGenerado = await GetComprobanteGeneradoFromTransaccion(id);
            }

            return response;

        }

        private async Task<ComprobanteGenerado> GetComprobanteGeneradoFromTransaccion(string id)
        {
            ComprobanteGenerado result = new ComprobanteGenerado();
            string query = $"SELECT * FROM SAR_FCRMVH WHERE SAR_FCRMVH_IDENTI = '{id}'";
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            result.ModuloComprobante = (string)reader["SAR_FCRMVH_MODFVT"];
                            result.CodigoComprobante = (string)reader["SAR_FCRMVH_CODFVT"];
                            result.NumeroComprobante = (int)reader["SAR_FCRMVH_NROFVT"];
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new BadRequestException($"Error al consultar el id de operacion");
                    }

                }


            }

            result.Impuestos.AddRange(await RecuperoImpuestosComprobante(result.ModuloComprobante,
                                                                         result.CodigoComprobante,
                                                                         result.NumeroComprobante));

            result.ImporteTotal = await RecuperoTotalComprobante(result.ModuloComprobante,
                                                                 result.CodigoComprobante,
                                                                 result.NumeroComprobante);

            return result;
        }
    }
    
}

