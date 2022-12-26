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
    public class RecibosRepository: Repository
    {
        
        public VT_TT_VTRMVH oVtrrch { get; set; }

        public RecibosRepository(ApiNosisContext context, Serilog.ILogger logger,IConfiguration configuration, VT_TT_VTRMVH oInstanceVTRRCH) :
            base(context, configuration, logger)
        {
            oVtrrch = oInstanceVTRRCH;
        }

        public async Task<Vtrmvh> Get(string codigoComprobante, int? numeroComprobante, int? idOperacion)
        {
            return await Context.Vtrmvh.Where(c => (c.Vtrmvh_Modfor == "VT" &&
                                            c.Vtrmvh_Codfor == codigoComprobante &&
                                            c.Vtrmvh_Nrofor == numeroComprobante) || (c.Usr_Vtrmvh_Idcrm == idOperacion && idOperacion != null))
                                        .Include(i => i.Aplicaciones)
                                        .Include(i => i.MediosDeCobro.Where(i=>i.Cjrmvi_Debhab =="D"))
                                        .FirstOrDefaultAsync();
        }
        public async Task<ReciboResponse> GraboRecibo(Vtrrch recibo, string tipoOperacion)
        {

            Vtmclh cliente = await Context.Vtmclh.Where(c=>c.VtmclhNrocta == recibo.Vtrmvh_Nrocta).FirstOrDefaultAsync();
            if (cliente==null)
            {
                Logger.Error($"El cliente {recibo.Vtrmvh_Nrocta} no existe.");
                return new ReciboResponse("Bad Request", 0, $"El cliente {recibo.Vtrmvh_Nrocta} no existe.");
            }

            
            oVtrrch.instancioObjeto(tipoOperacion);
            
            oVtrrch.asignoaTMWizard("VIRT_TIPPRC", "M", Logger);
            
            oVtrrch.MoveNext();

            Type typeRecibo = recibo.GetType();

            IEnumerable<PropertyInfo> listaPropiedades = typeRecibo.GetProperties();


            foreach (PropertyInfo propiedad in listaPropiedades)
            {

                if (propiedad.PropertyType == typeof(List<Vtrrcc01>))
                {

                    foreach (Vtrrcc01 item in recibo.Aplicaciones)
                    {
                        oVtrrch.asignoaTM("VTRRCC01", "", item, 2, Logger);
                    }
                }
                else if (propiedad.PropertyType == typeof(List<Vtrrcc04>))
                {

                    foreach (Vtrrcc04 item in recibo.MediosDeCobro)
                    {
                        oVtrrch.asignoaTM("VTRRCC04", "", item, 2, Logger);
                    }
                }
                else
                {
                    {
                        oVtrrch.asignoaTM("VTRRCH", propiedad.Name, propiedad.GetValue(recibo, null), 1, Logger);
                        //Logger.Information($"Campos {propiedad.Name} asignado con el valor {propiedad.GetValue(recibo, null)}");
                    }


                }
            }
            Save PerformedOperation = oVtrrch.save();

            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;

            oVtrrch.closeObjectInstance();

            if (result == false)
            {
                return new ReciboResponse("Bad Request", 0, mensajeError);
            }

            return new ReciboResponse("OK", 0, PerformedOperation.ComprobanteGenerado, "Comprobante generado");
        }

        internal Task<ReciboResponse> GraboAnulacion(Vtrrch reciboFormat, string v)
        {
            throw new NotImplementedException();
        }
    }
}

