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
    public class ClienteRepository: Repository
    {
        public VT_TT_VTMCLH oVTMCLH { get; set; }

        public ClienteRepository(ApiNosisContext context, Serilog.ILogger logger,IConfiguration configuration) :
            base(context, configuration, logger)
        {
            //oVTMCLH = oInstanceVTMCLH;
        }

        public async Task<Transaccion> GetTransaccionById(string id)
        {

            return await GetTransaccion(id, "SAR_VTMCLH");

        }

        public async Task<List<ClienteDTO>> Get(string numeroCliente)
        {

            Logger.Information($"Se recibio consulta de cliente {numeroCliente}");

            List<ClienteDTO> clientes = new List<ClienteDTO>();
            

            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {

                clientes.AddRange(await ExecuteStoredProcedure<ClienteDTO>("ALM_VtmclhGetForAPI",
                                                                            new Dictionary<string, object>{
                                                                                { "@Nrocta", numeroCliente }
                                                                            }));
                foreach (var item in clientes)
                {

                    
                    item.Impuestos.AddRange(await ExecuteStoredProcedure<ImpuestosDTO>("ALM_VtmcliGetForAPI",
                                                                            new Dictionary<string, object>{
                                                                                { "@Nrocta", numeroCliente }
                                                                            }));
                    
                    item.Contactos.AddRange(await ExecuteStoredProcedure<ContactosDTO>("ALM_VtmclcGetForAPI",
                                                                            new Dictionary<string, object>{
                                                                                { "@Nrocta", numeroCliente }
                                                                            }));
                }
            }
                
            Logger.Information($"Se recuperaron datos correctamente");
            return clientes;
        }



        public async Task<ClienteResponse> GraboClienteSoftland(VtmclhDTO cliente, string tipoOperacion)
        {

            string errorAltaCodigoPostal = "";
            
            errorAltaCodigoPostal = await GeneroCodigoPostal(cliente.VTMCLH_CODPAI, cliente.VTMCLH_CODPOS, cliente.VTMCLH_JURISD);

            if (errorAltaCodigoPostal != "")
            {
                return new ClienteResponse("Bad Request", 0, errorAltaCodigoPostal);
            }
            
            errorAltaCodigoPostal = await GeneroCodigoPostal(cliente.VTMCLH_PAIENT, cliente.VTMCLH_CODENT, cliente.VTMCLH_JURENT);
            
            if (errorAltaCodigoPostal != "")
            {
                return new ClienteResponse("Bad Request", 0, errorAltaCodigoPostal);
            }

            VT_TT_VTMCLH oVTMCLH = new VT_TT_VTMCLH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]);

            oVTMCLH.instancioObjeto(tipoOperacion);

            Type typeCliente = cliente.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typeCliente.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {
                if (propiedad.PropertyType == typeof(string))
                {
                    oVTMCLH.asignoaTM("VTMCLH", propiedad.Name, (string)propiedad.GetValue(cliente, null), 1, Logger);
                }

                if (propiedad.PropertyType == typeof(List<VtmclcDTO>))
                {
                    oVTMCLH.limpioGrilla("VTMCLC");
                    foreach (VtmclcDTO contacto in cliente.Contactos)
                    {
                        oVTMCLH.asignoaTM("VTMCLC", "", (VtmclcDTO)contacto, 2, Logger);
                    }
                }

                if (propiedad.PropertyType == typeof(List<VtmcliDTO>))
                {
                    //oVTMCLH.limpioGrilla("VTMCLI");
                    foreach (VtmcliDTO impuesto in cliente.Impuestos)
                    {
                        oVTMCLH.asignoaTM("VTMCLI", "", (VtmcliDTO)impuesto, 2, Logger);
                    }
                }


            }

            oVTMCLH.asignoaTM("VTMCLH", "VTMCLH_CODCRD", "NA", 1, Logger);
            oVTMCLH.asignoaTM("VTMCLH", "VTMCLH_ZONENT", "NA", 1, Logger);
            oVTMCLH.asignoaTM("VTMCLH", "VTMCLH_CODEXP", "2", 1, Logger);

            

            Save PerformedOperation = oVTMCLH.save();

            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;


            oVTMCLH.closeObjectInstance();

            if (result == false)
            {
                return new ClienteResponse("Bad Request", 0, mensajeError);
            }

            return new ClienteResponse("OK", 0, null, "Cliente generado");
        }

        public async Task<ClienteResponse> GraboClienteSql(ClienteDTO cliente)
        {
            InsertSqlHelpers sqlHelp= new InsertSqlHelpers(Configuration);
            
            string errorAltaCodigoPostal = "";

            errorAltaCodigoPostal = await GeneroCodigoPostal(cliente.Pais, cliente.CodigoPostal, cliente.Provincia);

            if (errorAltaCodigoPostal != "")
            {
                return new ClienteResponse("Bad Request", 0, errorAltaCodigoPostal);
            }

            errorAltaCodigoPostal = await GeneroCodigoPostal(cliente.PaisEntrega, cliente.CodigoPostalEntrega, cliente.ProvinciaEntrega);

            if (errorAltaCodigoPostal != "")
            {
                return new ClienteResponse("Bad Request", 0, errorAltaCodigoPostal);
            }

            List<KeyValuePair<string, object>> mapeoCampos = sqlHelp.CreateDictionarySAR_VTMCLH(cliente).ToList();

            string query= ArmoQueryInsertTablaSAR(mapeoCampos.Where(k => k.Value is not IEnumerable<object>).ToList(), "SAR_VTMCLH");

            foreach (KeyValuePair<string,object> tablaHija in mapeoCampos.Where(k=>k.Value is IEnumerable<object>).ToList())
            {
                foreach (var item in (IEnumerable<object>)tablaHija.Value)
                {
                    switch (tablaHija.Key)
                    {
                        case "USR_VTMCLI":
                            mapeoCampos = sqlHelp.CreateDictionarySAR_VTMCLI((ImpuestosDTO)item, cliente.IdOperacion).ToList();
                            query = ArmoQueryInsertTablaSAR(mapeoCampos,tablaHija.Key,query);
                            break;
                        case "USR_VTMCLC":
                            mapeoCampos = sqlHelp.CreateDictionarySAR_VTMCLC((ContactosDTO)item, cliente.IdOperacion).ToList();
                            query = ArmoQueryInsertTablaSAR(mapeoCampos, tablaHija.Key, query);
                            break;
                        default:
                            break;
                    }
                }
                
            }
            
            string errorMessage = await ExecuteSqlInsertToTablaSAR(query);
            
            
            return errorMessage != "" ? new ClienteResponse("Bad Request", cliente.IdOperacion, errorMessage) : 
                                        new ClienteResponse("OK", cliente.IdOperacion, null, "Petición procesada");

            
        }

        

        public async Task<ClienteResponse> ActualizoCliente(Vtmclh cliente)
        {
            string errorAltaCodigoPostal = "";
            string situacionDeIvaActual = "";

            errorAltaCodigoPostal = await GeneroCodigoPostal(cliente.VtmclhCodpai, cliente.VtmclhCodpos, cliente.VtmclhJurisd);

            if (errorAltaCodigoPostal != "")
            {
                return new ClienteResponse("Bad Request", 0, errorAltaCodigoPostal);
            }

            errorAltaCodigoPostal = await GeneroCodigoPostal(cliente.VtmclhPaient, cliente.VtmclhCodent, cliente.VtmclhJurent);

            if (errorAltaCodigoPostal != "")
            {
                return new ClienteResponse("Bad Request", 0, errorAltaCodigoPostal);
            }


            Vtmclh clienteAActualizar = await Context.Vtmclh
                                        .Where(c => c.VtmclhNrocta == cliente.VtmclhNrocta)
                                        .FirstOrDefaultAsync();
            if (clienteAActualizar == null)
            {
                return new ClienteResponse("Bad Request", 0, $"El cliente {cliente.VtmclhNrocta} no existe");
            }

            situacionDeIvaActual = clienteAActualizar.VtmclhCndiva;

            Type typeCliente = cliente.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typeCliente.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {

                var value = propiedad.GetValue(cliente, null);

                if (propiedad.PropertyType == typeof(string))
                {
                    
                    if ((string)value != "null" && (string)value != "NULL" &&
                            value != null && propiedad.Name != "VtmclhNrocta" &&
                            propiedad.Name != "Contactos")
                    {
                        if (propiedad.Name == "VtmclhFisjur")
                        {
                            if ((string)value != "J" && (string)value != "F")
                            {
                                return new ClienteResponse("Bad Request", 0, $"El campo Tipo de Persona tiene un valor inválido");
                            }
                        }
                        

                        if (propiedad.Name == "VtmclhLanexp")
                        {
                            if ((string)value != "1" && (string)value != "2" && (string)value != "3")
                            {
                                return new ClienteResponse("Bad Request", 0, $"El campo Idioma de referencia tiene un valor inválido");
                            }
                        }

                        typeCliente.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, clienteAActualizar, new object[] { value });
                    }
                }

            }

            clienteAActualizar.VtmclhFecmod = DateTime.Now;
            clienteAActualizar.VtmclhUltopr= "M";
            clienteAActualizar.VtmclhUserid = "API";

            try
            {
                await Context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return new ClienteResponse("Bad Request", 0, e.InnerException.Message);
            }

            foreach (Vtmclc contacto in cliente.Contactos)
            {
                contacto.VtmclcNrocta = cliente.VtmclhNrocta;
                ClienteResponse response = await this.actualizoContacto(contacto);
                if (response.Estado != 200)
                {
                    return response;
                }
            }

            foreach (Vtmcli impuesto in cliente.Impuestos)
            {
                impuesto.VtmcliNrocta = cliente.VtmclhNrocta;
                ClienteResponse response = await this.actualizoImpuesto(impuesto);
                if (response.Estado != 200)
                {
                    return response;
                }
            }

            //01/10/2021 - Se comenta dado que empiezan a informar impuestos desde app origen.
            //if (situacionDeIvaActual != clienteAActualizar.VtmclhCndiva)
            //{
            //    try
            //    {
            //        await Context.Database.BeginTransactionAsync();
            //        var rowsAffected = await Context.Database.ExecuteSqlRawAsync($"EXEC ALM_RegeneraVTMCLI @p0", parameters: new[] { cliente.VtmclhNrocta });
            //        await Context.Database.CommitTransactionAsync();
            //    }
            //    catch (Exception e)
            //    {
            //        return new ClienteResponse("Bad Request", 0, e.InnerException.Message);
            //    }

            //}

            return new ClienteResponse("OK", 0, null,"Cliente actualizado");

        }

        private async Task<ClienteResponse> actualizoContacto(Vtmclc contacto)
        {
            Vtmclc contactoAActualizar = await Context.Vtmclc
                                        .Where(c => c.VtmclcNrocta == contacto.VtmclcNrocta && c.VtmclcCodcon == contacto.VtmclcCodcon)
                                        .FirstOrDefaultAsync();
            if (contactoAActualizar == null)
            {
                Vtmclc nuevoContacto = new Vtmclc{};

                Type typeContacto = contacto.GetType();

                System.Reflection.PropertyInfo[] listaPropiedades = typeContacto.GetProperties();

                foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                {
                    string value = (string)propiedad.GetValue(contacto, null);
                    if (value != "null" && value != "NULL" && value != null )
                    {
                        typeContacto.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, nuevoContacto, new object[] { value });
                    }

                }

                
                nuevoContacto.VtmclcFecalt = DateTime.Now;
                nuevoContacto.VtmclcFecmod = DateTime.Now;
                nuevoContacto.VtmclcDebaja = "N";
                nuevoContacto.VtmclcOalias = "VTMCLC";
                nuevoContacto.VtmclcUltopr = "M";
                nuevoContacto.VtmclcUserid = "API";
                
                Context.Vtmclc.Add(nuevoContacto);

                try
                {
                    await Context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    return new ClienteResponse("Bad Request", 0, e.InnerException.Message);
                }
            }
            else
            {
                Type typeContacto = contacto.GetType();

                System.Reflection.PropertyInfo[] listaPropiedades = typeContacto.GetProperties();

                foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                {
                    string value = (string)propiedad.GetValue(contacto, null);
                    if (value != "null" && value != "NULL" && value != null && propiedad.Name != "VtmclcNrocta" && propiedad.Name != "VtmclcCodcon")
                    {

                        if (propiedad.Name == "VtmclcTipsex") { 
                        
                            if ((string)value != "M" && (string)value != "F")
                            {
                                return new ClienteResponse("Bad Request", 0, $"Contacto {contacto.VtmclcCodcon}: El campo Sexo tiene un valor inválido");
                            }
                        }

                        if (propiedad.Name == "VtmclhRecfac") { 

                            if ((string)value != "S" && (string)value != "N")
                            {
                                return new ClienteResponse("Bad Request", 0, $"Contacto {contacto.VtmclcCodcon}: El campo ReclamoFacturas tiene un valor inválido");
                            }
                        }
                        
                        typeContacto.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, contactoAActualizar, new object[] { value });
                    }

                }

                contactoAActualizar.VtmclcFecmod = DateTime.Now;
                contactoAActualizar.VtmclcUltopr = "M";
                contactoAActualizar.VtmclcUserid = "API";

                try
                {
                    await Context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    return new ClienteResponse("Bad Request", 0, e.InnerException.Message);
                }
            }
            return new ClienteResponse("OK", 0, new VtmclhDTO(), "Cliente actualizado");

        }

        private async Task<ClienteResponse> actualizoImpuesto(Vtmcli impuesto)
        {
            Vtmcli impuestoAActualizar = await Context.Vtmcli
                                        .Where(c => c.VtmcliNrocta == impuesto.VtmcliNrocta && c.VtmcliTipimp == impuesto.VtmcliTipimp)
                                        .FirstOrDefaultAsync();
            if (impuestoAActualizar == null)
            {
                Vtmcli nuevoImpuesto = new Vtmcli { };

                Type typeImpuesto = impuesto.GetType();

                System.Reflection.PropertyInfo[] listaPropiedades = typeImpuesto.GetProperties();

                foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                {
                    string value = (string)propiedad.GetValue(impuesto, null);
                    if (value != "null" && value != "NULL" && value != null)
                    {
                        typeImpuesto.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, nuevoImpuesto, new object[] { value });
                    }

                }


                nuevoImpuesto.VtmcliFecalt = DateTime.Now;
                nuevoImpuesto.VtmcliFecmod = DateTime.Now;
                nuevoImpuesto.VtmcliDebaja = "N";
                nuevoImpuesto.VtmcliOalias = "VTMCLI";
                nuevoImpuesto.VtmcliUltopr = "M";
                nuevoImpuesto.VtmcliUserid = "API";

                Context.Vtmcli.Add(nuevoImpuesto);

                try
                {
                    await Context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    return new ClienteResponse("Bad Request", 0, e.InnerException.Message);
                }
            }
            else
            {
                Type typeContacto = impuesto.GetType();

                System.Reflection.PropertyInfo[] listaPropiedades = typeContacto.GetProperties();

                foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                {
                    string value = (string)propiedad.GetValue(impuesto, null);
                    if (value != "null" && value != "NULL" && value != null && propiedad.Name != "VtmcliNrocta" && propiedad.Name != "VtmcliTipimp")
                    {

                        if (propiedad.Name == "VtmcliInclui")
                        {

                            if ((string)value != "S" && (string)value != "N")
                            {
                                return new ClienteResponse("Bad Request", 0, $"Impuesto {impuesto.VtmcliTipimp}: El campo incluido tiene un valor inválido");
                            }
                        }

                        if (propiedad.Name == "VtmcliCorres")
                        {

                            if ((string)value != "S" && (string)value != "N")
                            {
                                return new ClienteResponse("Bad Request", 0, $"Impuesto {impuesto.VtmcliTipimp}: El campo Corresponde tiene un valor inválido");
                            }
                        }

                        typeContacto.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, impuestoAActualizar, new object[] { value });
                    }

                }

                impuestoAActualizar.VtmcliFecmod = DateTime.Now;
                impuestoAActualizar.VtmcliUltopr = "M";
                impuestoAActualizar.VtmcliUserid = "API";

                try
                {
                    await Context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    return new ClienteResponse("Bad Request", 0, e.InnerException.Message);
                }
            }
            return new ClienteResponse("OK", 0, new VtmclhDTO(), "Cliente actualizado");

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


       

      


    }


}



