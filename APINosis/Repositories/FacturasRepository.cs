using APINosis.Entities;
using APINosis.Helpers;
using APINosis.Interfaces;
using APINosis.Models;
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

        public FacturasRepository(ApiNosisContext context, Serilog.ILogger logger,IConfiguration configuration, FC_RR_FCRMVH oInstanceFCRMVH) :
            base(context, configuration, logger)
        {
            oFcrmvh = oInstanceFCRMVH;
        }

        public FacturaResponse GraboFactura(Fcrmvh factura, string tipoOperacion)
        {

            oFcrmvh.instancioObjeto(tipoOperacion);

            oFcrmvh.asignoaTMWizard("VIRT_CIRCOM", factura.Virt_Circom);
            oFcrmvh.asignoaTMWizard("VIRT_CIRAPL", factura.Virt_Cirapl);
            oFcrmvh.asignoaTMWizard("VIRT_CODCVT", factura.Virt_Codcvt);

            oFcrmvh.MoveNext();

            Type typeFactura = factura.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typeFactura.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {

                if (propiedad.PropertyType == typeof(ICollection<Fcrmvi>))
                {
                    
                    foreach (Fcrmvi item in factura.Items)
                    {
                        oFcrmvh.asignoaTM("FCRMVI", "", item, 2);
                    }
                }
                else
                {
                    oFcrmvh.asignoaTM("FCRMVH", propiedad.Name, propiedad.GetValue(factura, null), 1);
                }


            }
            Save PerformedOperation = oFcrmvh.save();

            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;

            oFcrmvh.closeObjectInstance();

            if (result == false)
            {
                return new FacturaResponse("Bad Request", 0, mensajeError);
            }

            return new FacturaResponse("OK", 0, factura, "Comprobante generado exitosamente");
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

