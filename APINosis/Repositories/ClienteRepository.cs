using APINosis.Entities;
using APINosis.Models;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace APINosis.Repositories
{
    public class ClienteRepository : Repository
    {
  
        public ClienteRepository(ApiNosisContext context, IConfiguration configuration, Serilog.ILogger logger) :
            base(context, configuration, logger)
        {
           
        }


        public APIResponse GraboCliente(Cliente cliente)
        {
            Type OEType = Type.GetTypeFromProgID("cwlwoe.global");
            dynamic OEInst = Activator.CreateInstance(OEType);
            string[] userPassword = new string[] { "admin","" };
            object[] company = new string[] { "APINOSIS" };
            object[] objetoSoftland = new object[] { "VTMCLH",4,"NEW" };

            dynamic oApplication = OEType.InvokeMember("GetApplication", BindingFlags.InvokeMethod, null, OEInst, userPassword);
            //dynamic oApplication = OEInst.GetApplication("Admin", "");
          
            //dynamic oInstance = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, , objetoSoftland);
            dynamic oCompany = OEType.InvokeMember("Companies", BindingFlags.GetProperty, null, oApplication, company);

            dynamic oInstance = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, oCompany, objetoSoftland);

            dynamic oTable = OEType.InvokeMember("Table", BindingFlags.GetProperty, null, oInstance, null);
            dynamic oRow = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
            dynamic oField = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oRow, new object[] { "VTMCLH_NROCTA" });
            OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { cliente.NumeroCliente });

            oInstance.Tables.Rows(1).fields["VTMCLH_NROCTA"].values = cliente.NumeroCliente;
            oInstance.Tables.Rows(1).fields["VTMCLH_NOMBRE"].values = cliente.RazonSocial;
            oInstance.Tables.Rows(1).fields["VTMCLH_NROSUB"].values = cliente.NumeroSubcuenta;
            oInstance.Tables.Rows(1).fields["VTMCLH_DIRECC"].values = cliente.DireccionFiscal;
            oInstance.Tables.Rows(1).fields["VTMCLH_CODPAI"].values = cliente.Pais;
            oInstance.Tables.Rows(1).fields["VTMCLH_CODPOS"].values = cliente.CodigoPostal;
            oInstance.Tables.Rows(1).fields["VTMCLH_MUNICP"].values = cliente.Municipio;
            oInstance.Tables.Rows(1).fields["VTMCLH_CNDIVA"].values = cliente.SituacionFrenteAlIVA;
            oInstance.Tables.Rows(1).fields["VTMCLH_TIPDOC"].values = cliente.TipoDocumento;
            oInstance.Tables.Rows(1).fields["VTMCLH_NRODOC"].values = cliente.NumeroDocumento;
            oInstance.Tables.Rows(1).fields["VTMCLH_VNDDOR"].values = cliente.Vendedor;
            oInstance.Tables.Rows(1).fields["VTMCLH_COBRAD"].values = cliente.Cobrador;
            oInstance.Tables.Rows(1).fields["VTMCLH_JURISD"].values = cliente.Provincia;
            oInstance.Tables.Rows(1).fields["VTMCLH_CODZON"].values = cliente.Zona;
            oInstance.Tables.Rows(1).fields["VTMCLH_ACTIVD"].values = cliente.Actividad;
            oInstance.Tables.Rows(1).fields["VTMCLH_CATEGO"].values = cliente.Categoria;
            oInstance.Tables.Rows(1).fields["VTMCLH_CNDPAG"].values = cliente.CondicionDePago;
            oInstance.Tables.Rows(1).fields["VTMCLH_CNDPRE"].values = cliente.ListaPrecios;
            oInstance.Tables.Rows(1).fields["VTMCLH_CODCRD"].values = cliente.LimiteCredito;
            oInstance.Tables.Rows(1).fields["VTMCLH_DIRENT"].values = cliente.DireccionEntrega;
            oInstance.Tables.Rows(1).fields["VTMCLH_PAIENT"].values = cliente.PaisEntrega;
            oInstance.Tables.Rows(1).fields["VTMCLH_CODENT"].values = cliente.CodigoPostalEntrega;
            oInstance.Tables.Rows(1).fields["VTMCLH_JURENT"].values = cliente.ProvinciaEntrega;
            oInstance.Tables.Rows(1).fields["VTMCLH_ZONENT"].values = cliente.ZonaEntrega;
            oInstance.Tables.Rows(1).fields["VTMCLH_TIPDO1"].values = cliente.TipoDocumento1;
            oInstance.Tables.Rows(1).fields["VTMCLH_NRODO1"].values = cliente.TipoDocumento2;
            oInstance.Tables.Rows(1).fields["VTMCLH_TIPDO2"].values = cliente.TipoDocumento3;
            oInstance.Tables.Rows(1).fields["VTMCLH_NRODO2"].values = cliente.NumeroDocumento1;
            oInstance.Tables.Rows(1).fields["VTMCLH_TIPDO3"].values = cliente.NumeroDocumento2;
            oInstance.Tables.Rows(1).fields["VTMCLH_NRODO3"].values = cliente.NumeroDocumento3;
            oInstance.Tables.Rows(1).fields["VTMCLH_CODEXP"].values = cliente.TipoExportacion;
            oInstance.Tables.Rows(1).fields["VTMCLH_FISJUR"].values = cliente.TipodePersona;
            oInstance.Tables.Rows(1).fields["VTMCLH_APELL1"].values = cliente.ApellidoPaterno;
            oInstance.Tables.Rows(1).fields["VTMCLH_APELL2"].values = cliente.ApellidoMaterno;
            oInstance.Tables.Rows(1).fields["VTMCLH_NOMB01"].values = cliente.PrimerNombre;
            oInstance.Tables.Rows(1).fields["VTMCLH_NOMB02"].values = cliente.SegundoNombre;
            oInstance.Tables.Rows(1).fields["USR_VTMCLH_CODACT"].values = cliente.Activadora;
            oInstance.Tables.Rows(1).fields["USR_VTMCLH_MPAGO"].values = cliente.ModalidadPago;
            oInstance.Tables.Rows(1).fields["USR_VTMCLH_MAILFC"].values = cliente.EmailFacturas;
            oInstance.Tables.Rows(1).fields["USR_VTMCLH_MAILRC"].values = cliente.EmailRecibos;
            oInstance.Tables.Rows(1).fields["USR_VTMCLH_ENMAIL"].values = cliente.EnviaMail;
            oInstance.Tables.Rows(1).fields["USR_VTMCLH_FECANT"].values = cliente.FechaCambioRazonSocial;

            string errormessage = "";

            
            oInstance.Save(errormessage);

            return new APIResponse
            {
                estado = 200,
                titulo = "Grabado",
                mensaje = "Cliente generado ok"
            };
        }

    }
}

