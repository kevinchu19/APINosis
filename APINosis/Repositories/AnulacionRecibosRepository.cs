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
    public class AnulacionRecibosRepository: Repository
    {
        
        public VT_TT_VTRMVH_ANU oVtcanuwiz { get; set; }

        public AnulacionRecibosRepository(ApiNosisContext context, Serilog.ILogger logger,IConfiguration configuration, VT_TT_VTRMVH_ANU oInstanceVTCANUWIZ) :
            base(context, configuration, logger)
        {
            oVtcanuwiz = oInstanceVTCANUWIZ;
        }

        public async Task<ReciboResponse> GraboAnulacionRecibo(RecibosDTO recibo, string tipoOperacion)
        {

         
            oVtcanuwiz.instancioObjeto(tipoOperacion);

            oVtcanuwiz.asignoaTMWizard("VIRT_CODFOR", recibo.CodigoReciboAnular, Logger);
            oVtcanuwiz.asignoaTMWizard("VIRT_NROFOR", recibo.NumeroReciboAnular, Logger);
            try
            {
                oVtcanuwiz.MoveNext();
            }
            catch 
            {
                return new ReciboResponse("Bad Request", 0, $"El recibo {recibo.CodigoReciboAnular} - {recibo.NumeroReciboAnular} no existe o ya fue anulado.");
            }
            
            oVtcanuwiz.MoveNext();
            oVtcanuwiz.asignoaTMWizard("VIRT_CODCOM", recibo.CodigoComprobanteAGenerar, Logger);
            if (recibo.FechaContable != null)
            {
                oVtcanuwiz.asignoaTMWizard("VIRT_FCHMOV", recibo.CodigoComprobanteAGenerar, Logger);
            }
            oVtcanuwiz.MoveNext();
            Save processResult = oVtcanuwiz.Finish();
            oVtcanuwiz.closeObjectInstance();

            if (processResult.Result == false)
            {
                return new ReciboResponse("Bad Request", 0, processResult.errorMessage);
            }

            return new ReciboResponse("OK", 0, null, "Anulacion generada");
        }

        internal Task<ReciboResponse> GraboAnulacion(Vtrrch reciboFormat, string v)
        {
            throw new NotImplementedException();
        }
    }
}

