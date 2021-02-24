using APINosis.Entities;
using APINosis.Helpers;
using APINosis.Interfaces;
using APINosis.Models;
using APINosis.OE;
using AutoMapper;
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
        
        public IOEObject oVTMCLH { get; set; }
        public Translate Translate { get; }

        public ClienteRepository(ApiNosisContext context, Serilog.ILogger logger,IConfiguration configuration, IOEObject oInstanceVTMCLH, Translate translate) :
            base(context, configuration, logger)
        {
            oVTMCLH = oInstanceVTMCLH;
            Translate = translate;
        }
        
        public async Task<List<Vtmclh>> Get(string numeroCliente)
        {

            Logger.Information($"Se recibio consulta de cliente {numeroCliente}");
            
            List<Vtmclh> clientes = await Context.Vtmclh
                .Where(c => c.VtmclhNrocta == numeroCliente || numeroCliente == null)
                .Include(c=>c.Contactos)
                .ToListAsync();

            Logger.Information($"Se recuperaron datos correctamente");
            return clientes;
        }



        public async Task<ClienteResponse> GraboCliente(VtmclhDTO cliente, string tipoOperacion)
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

            oVTMCLH.instancioObjeto(tipoOperacion);

            Type typeCliente = cliente.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typeCliente.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {
                if (propiedad.PropertyType == typeof(string))
                {
                    oVTMCLH.asignoaTM("VTMCLH", propiedad.Name, (string)propiedad.GetValue(cliente, null), 1);
                }

                if (propiedad.PropertyType == typeof(List<VtmclcDTO>))
                {
                    oVTMCLH.limpioGrilla("VTMCLC");
                    foreach (VtmclcDTO contacto in cliente.Contactos)
                    {
                        oVTMCLH.asignoaTM("VTMCLC", "", (VtmclcDTO)contacto, 2);
                    }
                }

                
            }

            oVTMCLH.asignoaTM("VTMCLH", "VTMCLH_CODCRD", "NA", 1);
            oVTMCLH.asignoaTM("VTMCLH", "VTMCLH_ZONENT", "NA", 1);
            oVTMCLH.asignoaTM("VTMCLH", "VTMCLH_CODEXP", "2", 1);

            

            Save PerformedOperation = oVTMCLH.save();

            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;


            oVTMCLH.closeObjectInstance();

            if (result == false)
            {
                return new ClienteResponse("Bad Request", 0, mensajeError);
            }

            return new ClienteResponse("OK", 0, cliente);
        }

        public async Task<ClienteResponse> ActualizoCliente(Vtmclh cliente)
        {
            string errorAltaCodigoPostal = "";

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
            
            
            return new ClienteResponse("OK", 0);

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
            return new ClienteResponse("OK", 0);

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
                    GrtpacCodpro = jurisdiccion,
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

