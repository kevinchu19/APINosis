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

        public async Task<ReciboResponse> GraboRecibo(Vtrrch recibo, string tipoOperacion)
        {

            Vtmclh cliente = await Context.Vtmclh.Where(c=>c.VtmclhNrocta == recibo.Vtrmvh_Nrocta).FirstOrDefaultAsync();
            if (cliente==null)
            {
                return new ReciboResponse("Bad Request", 0, $"El cliente {recibo.Vtrmvh_Nrocta} no existe.");
            }

            oVtrrch.instancioObjeto(tipoOperacion);

            oVtrrch.asignoaTMWizard("VIRT_TIPPRC", "M");
            
            oVtrrch.MoveNext();

            Type typeRecibo = recibo.GetType();

            IEnumerable<PropertyInfo> listaPropiedades = typeRecibo.GetProperties();


            foreach (PropertyInfo propiedad in listaPropiedades)
            {

                if (propiedad.PropertyType == typeof(ICollection<Vtrrcc01>))
                {

                    foreach (Vtrrcc01 item in recibo.Aplicaciones)
                    {
                        oVtrrch.asignoaTM("VTRRCC01", "", item, 2);
                    }
                }
                else if (propiedad.PropertyType == typeof(ICollection<Vtrrcc04>))
                {

                    foreach (Vtrrcc04 item in recibo.MediosDeCobro)
                    {
                        oVtrrch.asignoaTM("VTRRCC04", "", item, 2);
                    }
                }
                else
                {
                    {
                        oVtrrch.asignoaTM("VTRRCH", propiedad.Name, propiedad.GetValue(recibo, null), 1);
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

