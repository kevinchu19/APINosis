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
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace APINosis.Repositories
{
    public class ContratoRepository: Repository
    {
        
        public CV_RR_CVMCTH oCvmcth { get; set; }        

        public ContratoRepository(ApiNosisContext context, Serilog.ILogger logger,IConfiguration configuration) :
            base(context, configuration, logger)
        {
            //oCvmcth = oInstanceCvmcth;
        }
        
        public async Task<List<ContratosDTO>> Get(string? tipoContrato, string codigoContrato, int numeroExtension)
        {

            Logger.Information($"Se recibio consulta de contrato {tipoContrato} - {codigoContrato} - {numeroExtension}");

            List<ContratosDTO> contratos = new List<ContratosDTO>();


            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {

                contratos.AddRange(await ExecuteStoredProcedure<ContratosDTO>("ALM_CvmcthGetForAPI",
                                                                            new Dictionary<string, object>{
                                                                                { "@Codcon", tipoContrato},
                                                                                { "@Nrocon", codigoContrato},
                                                                                { "@Nroext", numeroExtension}
                                                                            }));
                foreach (var item in contratos)
                {


                    item.Items.AddRange(await ExecuteStoredProcedure<ItemsContratosDTO>("ALM_CvmctiGetForAPI",
                                                                            new Dictionary<string, object>{
                                                                                { "@Codcon", tipoContrato},
                                                                                { "@Nrocon", codigoContrato},
                                                                                { "@Nroext", numeroExtension}
                                                                            }));
                }
            }

            Logger.Information($"Se recuperaron datos correctamente");
            return contratos;
        }



        public async Task<ContratoResponse> GraboContrato(Cvmcth contrato, string tipoOperacion)
        {

            CV_RR_CVMCTH oCvmcth = new CV_RR_CVMCTH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]);

            oCvmcth.instancioObjeto(tipoOperacion);

            Type typeContrato = contrato.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typeContrato.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {

                if (propiedad.PropertyType == typeof(ICollection<Cvmcti>))
                {
                    oCvmcth.limpioGrilla("CVMCTI01");
                    foreach (Cvmcti item in contrato.Items)
                    {
                        oCvmcth.asignoaTM("CVMCTI01", "", item, 2, Logger);
                    }
                }
                else
                {
                    oCvmcth.asignoaTM("CVMCTH01", propiedad.Name, propiedad.GetValue(contrato, null), 1, Logger);
                }

                
            }
            Save PerformedOperation = oCvmcth.save();

            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;


            oCvmcth.closeObjectInstance();

            if (result == false)
            {
                return new ContratoResponse("Bad Request", 0, mensajeError);
            }

            return new ContratoResponse("OK", 0, null, "Contrato generado");
        }

        public async Task<ContratoResponse> ActualizoContrato(Cvmcth contrato)
        {

            Cvmcth contratoAActualizar = await Context.Cvmcth
                                        .FindAsync(new object[] { contrato.Cvmcth_Codcon,
                                                                  contrato.Cvmcth_Nrocon,
                                                                  contrato.Cvmcth_Nroext });
            if (contratoAActualizar == null)
            {
                return new ContratoResponse("Not Found", 0, $"El contrato no existe");
            }

            Type typeContrato= contrato.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typeContrato.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {

                var value = propiedad.GetValue(contrato, null);

                if (propiedad.PropertyType == typeof(string))
                {
                    
                    if ((string)value != "null" && (string)value != "NULL" &&
                            value != null && 
                            propiedad.Name != "Cvmcth_Codcon" &&
                            propiedad.Name != "Cvmcth_Nrocon" &&
                            propiedad.Name != "Cvmcth_Nroext" &&
                            propiedad.Name != "Items")
                    {
                        switch (propiedad.Name)
                        {
                            case "Cvmcth_Desfre":
                                short valorAAsignar = 0;
                                switch (value)
                                {
                                    case "A":
                                        valorAAsignar = 360;
                                        break;
                                    case "M":
                                        valorAAsignar = 30;
                                        break;
                                    case "B":
                                        valorAAsignar = 60;
                                        break;
                                    case "T":
                                        valorAAsignar = 40;
                                        break;
                                    case "C":
                                        valorAAsignar = 30;
                                        break;
                                    case "S":
                                        valorAAsignar = 180;
                                        break;
                                    default:
                                        break;
                                }
                                contratoAActualizar.Cvmcth_Frefac = valorAAsignar;
                                break;
                            case "Cvmcth_Nrocta": case "Cvmcth_Nrosub":
                                string codigoCliente = propiedad.Name == "Cvmcth_Nrocta" ? contrato.Cvmcth_Nrocta : contrato.Cvmcth_Nrosub; 
                                bool ExisteCliente = await ValidoVTMCLH(codigoCliente);
                                if (ExisteCliente == false)
                                {
                                    return new ContratoResponse("Bad Request", 0, $"El codigo {codigoCliente} no se encuentra creado como cliente.");
                                }
                                typeContrato.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, contratoAActualizar, new object[] { value });
                                break;

                            case "Cvmcth_Codcvt":
                                bool ExisteComprobante = await ValidoGRCCBH(contrato);
                                if (ExisteComprobante ==false)
                                {
                                    return new ContratoResponse("Bad Request", 0, $"El comprobante de ventas {contrato.Cvmcth_Codcvt} no existe.");
                                }
                                typeContrato.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, contratoAActualizar, new object[] { value });
                                break;
                            default:
                                typeContrato.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, contratoAActualizar, new object[] { value });
                                break;
                        }

                        
                    }
                }

            }

            contratoAActualizar.Cvmcth_Fecmod = DateTime.Now;
            contratoAActualizar.Cvmcth_Ultopr= "M";
            contratoAActualizar.Cvmcth_Userid = "API";

            try
            {
                await Context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return new ContratoResponse("Bad Request", 0, e.InnerException.Message);
            }

            foreach (Cvmcti items in contrato.Items)
            {
                items.Cvmcti_Codcon = contrato.Cvmcth_Codcon;
                items.Cvmcti_Nrocon = contrato.Cvmcth_Nrocon;
                items.Cvmcti_Nroext = contrato.Cvmcth_Nroext;
                ContratoResponse response = await this.actualizoItem(items, contrato);
                if (response.Estado != 200)
                {
                    return response;
                }
            }

            return new ContratoResponse("OK", 0, null, "Contrato actualizado");

        }

        private async Task<bool> ValidoVTMCLH(string codigoCliente)
        {
            Vtmclh cliente = await Context.Vtmclh.FindAsync(new object[] { codigoCliente });
            if (cliente != null)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> ValidoGRCCBH(Cvmcth contrato)
        {
            Grccbh comprobanteVT = await Context.Grccbh.FindAsync(new object[] { "VT", contrato.Cvmcth_Codcvt });
            if (comprobanteVT != null)
            {
                return true;
            }
            return false;
        }

        private async Task<ContratoResponse> actualizoItem(Cvmcti item, Cvmcth contrato)
        {
            Cvmcti ItemAActualizar = await Context.Cvmcti
                                        .FindAsync(new object[] { item.Cvmcti_Codcon, item.Cvmcti_Nrocon,
                                                                  item.Cvmcti_Nroext, item.Cvmcti_Nroitm });
            if (ItemAActualizar == null)
            {
                Cvmcti nuevoItem = new Cvmcti{};

                Type typeItem = item.GetType();

                System.Reflection.PropertyInfo[] listaPropiedades = typeItem.GetProperties();

                foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                {
               
                        object value = propiedad.GetValue(item, null);
                        switch (propiedad.GetValue(item, null))
                        {
                            case string:
                                if ((string)value != "null" && (string)value != "NULL" && value != null)
                                {
                                    typeItem.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, nuevoItem, new object[] { value });
                                }
                                break;
                            case int:
                                if ((int)value != 0)
                                {
                                    typeItem.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, nuevoItem, new object[] { value });
                                }
                                break;
                            case short:
                                if ((short)value != 0)
                                {
                                    typeItem.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, nuevoItem, new object[] { value });
                                }
                                break;
                            case decimal:
                                if ((decimal)value != 0)
                                {
                                    typeItem.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, nuevoItem, new object[] { value });
                                }
                                break;
                            default:
                                break;
                        }

                   
                }

                nuevoItem.Cvmcti_Preaju = 0;
                nuevoItem.Cvmcti_Auxaju = 0;
                nuevoItem.Cvmcti_Modcpt = "VT";
                nuevoItem.Cvmcti_Tipcpt = "A";
                nuevoItem.Cvmcti_Codcpt = "V001";
                nuevoItem.Cvmcti_Stocks = "N";
                nuevoItem.Cvmcti_Cuenta = "41010101";
                nuevoItem.Cvmcti_Unimed = "UN";
                nuevoItem.Cvmcti_Debhab = "H";
                nuevoItem.Cvmcti_Fecalt= DateTime.Now;
                nuevoItem.Cvmcti_Fecmod = DateTime.Now;
                nuevoItem.Cvmcti_Debaja = "N";
                nuevoItem.Cvmcti_Oalias = "CVMCTI01";
                nuevoItem.Cvmcti_Ultopr = "M";
                nuevoItem.Cvmcti_Userid = "API";
                
                Context.Cvmcti.Add(nuevoItem);

                try
                {
                    await Context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    return new ContratoResponse("Bad Request", 0, e.InnerException.Message);
                }
            }
            else
            {
                Type typeItem = item.GetType();

                System.Reflection.PropertyInfo[] listaPropiedades = typeItem.GetProperties();

                foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                {
                    if (propiedad.Name != "Cvmcti_Codcon" &&
                        propiedad.Name != "Cvmcti_Nrocon" &&
                        propiedad.Name != "Cvmcti_Nroext" &&
                        propiedad.Name != "Cvmcti_Nroitm")
                    {
                        object value = propiedad.GetValue(item, null);
                        switch (propiedad.GetValue(item,null))
                        {
                            case string:
                                if ((string)value != "null" && (string)value != "NULL" && value != null)
                                {
                                    typeItem.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, ItemAActualizar, new object[] { value });
                                }
                                break;
                            case int: 
                                if ((int)value != 0)
                                {
                                    typeItem.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, ItemAActualizar, new object[] { value });
                                }
                                break;
                            case short:
                                if ((short)value != 0)
                                {
                                    typeItem.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, ItemAActualizar, new object[] { value });
                                }
                                break;
                            case decimal:
                                if ((decimal)value != 0)
                                {
                                    typeItem.InvokeMember(propiedad.Name, BindingFlags.SetProperty, null, ItemAActualizar, new object[] { value });
                                }
                                break;
                            default:
                                break;
                        }   

                    }

                }

                ItemAActualizar.Cvmcti_Fecmod = DateTime.Now;
                ItemAActualizar.Cvmcti_Ultopr= "M";
                ItemAActualizar.Cvmcti_Userid = "API";

                try
                {
                    await Context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    return new ContratoResponse("Bad Request", 0, e.InnerException.Message);
                }
            }
            return new ContratoResponse("OK", 0, contrato, "Contrato actualizado");

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

