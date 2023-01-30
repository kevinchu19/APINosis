using APINosis.Helpers;
using APINosis.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Repositories
{
    public class InsertSqlHelpers
    {
        private readonly IConfiguration Configuration;

        public InsertSqlHelpers(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public Dictionary<string, object> CreateDictionarySAR_VTMCLH(ClienteDTO cliente)
        {
            Dictionary<string, object> Sar_Vtmclh = new Dictionary<string, object>();

            Sar_Vtmclh.Add("SAR_VTMCLH_IDENTI", FormatStringSql(cliente.IdOperacion));
            Sar_Vtmclh.Add("SAR_VTMCLH_STATUS", FormatStringSql("N"));
            Sar_Vtmclh.Add("SAR_VTMCLH_NROCTA", FormatStringSql(cliente.NumeroCliente));
            Sar_Vtmclh.Add("SAR_VTMCLH_NOMBRE", FormatStringSql(cliente.RazonSocial));
            Sar_Vtmclh.Add("SAR_VTMCLH_TIPDOC", FormatStringSql(cliente.TipoDocumento));
            Sar_Vtmclh.Add("SAR_VTMCLH_NRODOC", FormatStringSql(cliente.NumeroDocumento));
            Sar_Vtmclh.Add("SAR_VTMCLH_CODPAI", FormatStringSql(cliente.Pais));
            Sar_Vtmclh.Add("SAR_VTMCLH_CODPOS", FormatStringSql(cliente.CodigoPostal));
            Sar_Vtmclh.Add("SAR_VTMCLH_JURISD", FormatStringSql(cliente.Provincia));
            Sar_Vtmclh.Add("SAR_VTMCLH_CNDIVA", FormatStringSql(cliente.SituacionFrenteAlIva));
            Sar_Vtmclh.Add("SAR_VTMCLH_VNDDOR", FormatStringSql(cliente.Vendedor));
            Sar_Vtmclh.Add("SAR_VTMCLH_COBRAD", FormatStringSql(cliente.Cobrador));
            Sar_Vtmclh.Add("SAR_VTMCLH_CODZON", FormatStringSql(cliente.Zona));
            Sar_Vtmclh.Add("SAR_VTMCLH_CNDPAG", FormatStringSql(cliente.CondicionDePago));
            Sar_Vtmclh.Add("SAR_VTMCLH_CODCRD", FormatStringSql("NA"));
            Sar_Vtmclh.Add("SAR_VTMCLH_ERRMSG", "NULL");
            Sar_Vtmclh.Add("SAR_VTMCLH_NROSUB", FormatStringSql(cliente.NumeroSubcuenta));
            Sar_Vtmclh.Add("SAR_VTMCLH_TIPDO1", FormatStringSql(cliente.TipoDocumento1));
            Sar_Vtmclh.Add("SAR_VTMCLH_NRODO1", FormatStringSql(cliente.NumeroDocumento1));
            Sar_Vtmclh.Add("SAR_VTMCLH_TIPDO2", FormatStringSql(cliente.TipoDocumento2));
            Sar_Vtmclh.Add("SAR_VTMCLH_NRODO2", FormatStringSql(cliente.NumeroDocumento2));
            Sar_Vtmclh.Add("SAR_VTMCLH_TIPDO3", FormatStringSql(cliente.TipoDocumento3));
            Sar_Vtmclh.Add("SAR_VTMCLH_NRODO3", FormatStringSql(cliente.NumeroDocumento3));
            Sar_Vtmclh.Add("SAR_VTMCLH_TIPDO4", "NULL");
            Sar_Vtmclh.Add("SAR_VTMCLH_NRODO4", "NULL");
            Sar_Vtmclh.Add("SAR_VTMCLH_CATEGO", FormatStringSql(cliente.Categoria));
            Sar_Vtmclh.Add("SAR_VTMCLH_DIRECC", FormatStringSql(cliente.DireccionFiscal));
            Sar_Vtmclh.Add("SAR_VTMCLH_NUMERO", "NULL");
            Sar_Vtmclh.Add("SAR_VTMCLH_DPPISO", "NULL");
            Sar_Vtmclh.Add("SAR_VTMCLH_DEPTOS", "NULL");
            Sar_Vtmclh.Add("SAR_VTMCLH_FISJUR", FormatStringSql(cliente.TipodePersona));
            Sar_Vtmclh.Add("SAR_VTMCLH_NOMB01", FormatStringSql(cliente.PrimerNombre));
            Sar_Vtmclh.Add("SAR_VTMCLH_NOMB02", FormatStringSql(cliente.SegundoNombre));
            Sar_Vtmclh.Add("SAR_VTMCLH_APELL1", FormatStringSql(cliente.ApellidoPaterno));
            Sar_Vtmclh.Add("SAR_VTMCLH_APELL2", FormatStringSql(cliente.ApellidoMaterno));
            Sar_Vtmclh.Add("SAR_VTMCLH_DIREML", "NULL");
            Sar_Vtmclh.Add("SAR_VTMCLH_CODLIS", FormatStringSql(cliente.ListaPrecios));
            Sar_Vtmclh.Add("SAR_VTMCLH_INHABI", FormatStringSql("N"));
            Sar_Vtmclh.Add("SAR_VTMCLH_CODJOB", "NULL");
            Sar_Vtmclh.Add("SAR_VTMCLH_EJEAUT", FormatStringSql("N"));
            Sar_Vtmclh.Add("SAR_VTMCLH_JURENT", FormatStringSql(cliente.ProvinciaEntrega));
            Sar_Vtmclh.Add("USR_VTMCLH_ACTIVD", FormatStringSql(cliente.Actividad));
            Sar_Vtmclh.Add("USR_VTMCLH_DIRENT", FormatStringSql(cliente.DireccionEntrega));
            Sar_Vtmclh.Add("USR_VTMCLH_PAIENT", FormatStringSql(cliente.PaisEntrega));
            Sar_Vtmclh.Add("USR_VTMCLH_CODENT", FormatStringSql(cliente.CodigoPostalEntrega));
            Sar_Vtmclh.Add("USR_VTMCLH_CODEXP", FormatStringSql("2"));
            Sar_Vtmclh.Add("USR_VTMCLH_ZONENT", FormatStringSql("NA"));
            Sar_Vtmclh.Add("USR_VTMCLH_CODACT", FormatStringSql(cliente.Activadora));
            Sar_Vtmclh.Add("USR_VTMCLH_MPAGO", FormatStringSql(cliente.ModalidadPago));
            Sar_Vtmclh.Add("USR_VTMCLH_MAILFC", FormatStringSql(cliente.EmailFacturas));
            Sar_Vtmclh.Add("USR_VTMCLH_MAILRC", FormatStringSql(cliente.EmailRecibos));
            Sar_Vtmclh.Add("USR_VTMCLH_ENMAIL", FormatStringSql(cliente.EnviaMail));
            Sar_Vtmclh.Add("USR_VTMCLH_FECANT", FormatStringSql(cliente.FechaCambioRazonSocial));
            Sar_Vtmclh.Add("USR_VTMCLH_LOCAL1", FormatStringSql(cliente.Localidad));
            Sar_Vtmclh.Add("USR_VTMCLH_LOCAL2", FormatStringSql(cliente.LocalidadEntrega));
            Sar_Vtmclh.Add("USR_VTMCLH_LANEXP", FormatStringSql(cliente.IdiomaReferencia));
            Sar_Vtmclh.Add("SAR_VT_FECALT", "GETDATE()");
            Sar_Vtmclh.Add("SAR_VT_FECMOD", "GETDATE()");
            Sar_Vtmclh.Add("SAR_VT_USERID", FormatStringSql("API"));
            Sar_Vtmclh.Add("SAR_VT_ULTOPR", FormatStringSql("A"));
            Sar_Vtmclh.Add("SAR_VT_DEBAJA", FormatStringSql("N"));
            Sar_Vtmclh.Add("SAR_VT_OALIAS", FormatStringSql("SAR_VTMCLH"));

            Sar_Vtmclh.Add("USR_VTMCLI", cliente.Impuestos);
            Sar_Vtmclh.Add("USR_VTMCLC", cliente.Contactos);

            return Sar_Vtmclh;
        }

        public Dictionary<string, object> CreateDictionarySAR_VTMCLI(ImpuestosDTO impuestoCliente, int idOperacion)
        {
            Dictionary<string, object> Sar_Vtmcli = new Dictionary<string, object>();

            Sar_Vtmcli.Add("USR_VTMCLI_IDENTI", FormatStringSql(idOperacion));
            Sar_Vtmcli.Add("USR_VTMCLI_TIPIMP", FormatStringSql(impuestoCliente.CodigoImpuesto));
            Sar_Vtmcli.Add("USR_VTMCLI_INCLUI", FormatStringSql(impuestoCliente.IVAIncluido));
            Sar_Vtmcli.Add("USR_VTMCLI_CORRES", FormatStringSql(impuestoCliente.Corresponde));

            return Sar_Vtmcli;
        }

        public Dictionary<string, object> CreateDictionarySAR_VTMCLC(ContactosDTO contactoCliente, int idOperacion)
        {
            Dictionary<string, object> Sar_Vtmclc = new Dictionary<string, object>();

            Sar_Vtmclc.Add("USR_VTMCLC_IDENTI", FormatStringSql(idOperacion));
            Sar_Vtmclc.Add("USR_VTMCLC_CODCON", FormatStringSql(contactoCliente.Nombre));
            Sar_Vtmclc.Add("USR_VTMCLC_PUESTO", FormatStringSql(contactoCliente.Puesto));
            Sar_Vtmclc.Add("USR_VTMCLC_OBSERV", FormatStringSql(contactoCliente.Observacion));
            Sar_Vtmclc.Add("USR_VTMCLC_TIPSEX", FormatStringSql(contactoCliente.Sexo));
            Sar_Vtmclc.Add("USR_VTMCLC_DIREML", FormatStringSql(contactoCliente.Email));
            Sar_Vtmclc.Add("USR_VTMCLC_TELINT", FormatStringSql(contactoCliente.Telefono));
            Sar_Vtmclc.Add("USR_VTMCLC_CELULA", FormatStringSql(contactoCliente.Celular));
            Sar_Vtmclc.Add("USR_VTMCLC_RECFAC", FormatStringSql(contactoCliente.ReclamoFacturas));

            return Sar_Vtmclc;
        }

        private string FormatStringSql(object value)
        {
            if (value ==null)
            {
                return "NULL";
            }

            if (value.ToString() =="NULL")
            {
                return "NULL";
            }
            return "'" + value.ToString() + "'";
         
        }

      
    }
}
