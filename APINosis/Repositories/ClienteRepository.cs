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



        public ClienteResponse GraboCliente(VtmclhDTO cliente, string tipoOperacion)
        {


            GeneroCodigoPostal(cliente);

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

        private async void GeneroCodigoPostal(VtmclhDTO cliente)
        {
            Grtpac codigoPostal = await Context.Grtpac
                                        .Where(c => c.GrtpacCodpai == cliente.VTMCLH_CODPAI && c.GrtpacCodpos == cliente.VTMCLH_CODPOS)
                                        .FirstOrDefaultAsync();
            if (codigoPostal == null)
            {
                Grtpac newCodigoPostal = new Grtpac
                {
                    GrtpacCodpai = cliente.VTMCLH_CODPAI,
                    GrtpacCodpos = cliente.VTMCLH_CODPOS,
                    GrtpacDescrp = "Generado Automáticamente",
                    GrtpacPaipro = cliente.VTMCLH_CODPAI,
                    GrtpacCodpro = cliente.VTMCLH_JURISD,
                    GrtpacFecalt = DateTime.Now,
                    GrtpacFecmod = DateTime.Now,
                    GrtpacUltopr = "A",
                    GrtpacOalias = "GRTPAC",
                    GrtpacDebaja = "N",
                    GrtpacUserid = "API-CRM"
                };
                await Context.Grtpac.AddAsync(newCodigoPostal);

                await Context.SaveChangesAsync();
            }
        }
    }
}

