using ApiNosis.Models;
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
            Dictionary<string, object> Sar_Vtmclc = new Dictionary<string, object>();

            Sar_Vtmclc.Add("USR_VTMCLI_IDENTI", FormatStringSql(idOperacion));
            Sar_Vtmclc.Add("USR_VTMCLI_TIPIMP", FormatStringSql(impuestoCliente.CodigoImpuesto));
            Sar_Vtmclc.Add("USR_VTMCLI_INCLUI", FormatStringSql(impuestoCliente.IVAIncluido));
            Sar_Vtmclc.Add("USR_VTMCLI_CORRES", FormatStringSql(impuestoCliente.Corresponde));

            Sar_Vtmclc.Add("USR_VT_FECALT", "GETDATE()");
            Sar_Vtmclc.Add("USR_VT_FECMOD", "GETDATE()");
            Sar_Vtmclc.Add("USR_VT_USERID", FormatStringSql("API"));
            Sar_Vtmclc.Add("USR_VT_ULTOPR", FormatStringSql("A"));
            Sar_Vtmclc.Add("USR_VT_DEBAJA", FormatStringSql("N"));
            Sar_Vtmclc.Add("USR_VT_OALIAS", FormatStringSql("USR_VTMCLI"));

            return Sar_Vtmclc;
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


            Sar_Vtmclc.Add("USR_VT_FECALT", "GETDATE()");
            Sar_Vtmclc.Add("USR_VT_FECMOD", "GETDATE()");
            Sar_Vtmclc.Add("USR_VT_USERID", FormatStringSql("API"));
            Sar_Vtmclc.Add("USR_VT_ULTOPR", FormatStringSql("A"));
            Sar_Vtmclc.Add("USR_VT_DEBAJA", FormatStringSql("N"));
            Sar_Vtmclc.Add("USR_VT_OALIAS", FormatStringSql("USR_VTMCLC"));

            return Sar_Vtmclc;
        }


        public Dictionary<string, object> CreateDictionarySAR_FCRMVH(FacturasDTO facturas, int idOperacion)
        {
            Dictionary<string, object> Sar_Fcrmvh = new Dictionary<string, object>();

            Sar_Fcrmvh.Add("SAR_FCRMVH_IDENTI", FormatStringSql(facturas.IdOperacion));

            Sar_Fcrmvh.Add("SAR_FCRMVH_STATUS", FormatStringSql("N"));
            Sar_Fcrmvh.Add("SAR_FCRMVH_CIRCOM", FormatStringSql(facturas.CircuitoOrigen));
            Sar_Fcrmvh.Add("SAR_FCRMVH_CIRAPL", FormatStringSql(facturas.CircuitoAplicacion));
            Sar_Fcrmvh.Add("USR_FCRMVH_CODCVT", FormatStringSql(facturas.ComprobanteVentas));
            Sar_Fcrmvh.Add("SAR_FCRMVH_FCHMOV", FormatStringSql(facturas.FechaContable));
            Sar_Fcrmvh.Add("SAR_FCRMVH_NROCTA", FormatStringSql(facturas.Cliente));
            Sar_Fcrmvh.Add("USR_FCRMVH_NROSUB", FormatStringSql(facturas.CodigoSubcuenta));
            Sar_Fcrmvh.Add("SAR_FCRMVH_DIRENT", FormatStringSql(facturas.DireccionEntrega));
            Sar_Fcrmvh.Add("SAR_FCRMVH_PAIENT", FormatStringSql(facturas.PaisEntrega));
            Sar_Fcrmvh.Add("SAR_FCRMVH_CODENT", FormatStringSql(facturas.CodPosEntrega));
            Sar_Fcrmvh.Add("SAR_FCRMVH_VNDDOR", FormatStringSql(facturas.Vendedor));
            Sar_Fcrmvh.Add("USR_FCRMVH_CNDPAG", FormatStringSql(facturas.CondicionPago));
            Sar_Fcrmvh.Add("SAR_FCRMVH_CODLIS", FormatStringSql(facturas.ListaPrecios));
            Sar_Fcrmvh.Add("SAR_FCRMVH_TEXTOS", FormatStringSql(facturas.Texto));
            Sar_Fcrmvh.Add("SAR_FCRMVH_COFLIS", FormatStringSql(facturas.CoeficienteDeuda));
            Sar_Fcrmvh.Add("SAR_FCRMVH_COFFAC", FormatStringSql(facturas.CoeficienteEmision));
            Sar_Fcrmvh.Add("SAR_FCRMVH_COFDEU", FormatStringSql(facturas.CoeficienteRegistracion));
            Sar_Fcrmvh.Add("SAR_FCRMVH_JURISD", FormatStringSql(facturas.Jurisdiccion));
            Sar_Fcrmvh.Add("USR_FCRMVH_TIPEXP", FormatStringSql(facturas.TipoExportacion));
            Sar_Fcrmvh.Add("USR_FCRMVH_TIPDOP", FormatStringSql(facturas.TipoDatoOpcionalAFIP));
            Sar_Fcrmvh.Add("USR_FCRMVH_VALDOP", FormatStringSql(facturas.ValorDatoOpcionalAFIP));
            Sar_Fcrmvh.Add("USR_FCRMVH_MPAGO", FormatStringSql(facturas.ModalidadPago));
            Sar_Fcrmvh.Add("USR_FCRMVH_LOCAL2", FormatStringSql(facturas.LocalidadEntrega));
            Sar_Fcrmvh.Add("USR_FCRMVH_SUBPO2", FormatStringSql(facturas.CodigoPostalExtendidoEntrega));
            Sar_Fcrmvh.Add("USR_FCRMVH_FCHFAC", FormatStringSql(facturas.FechaFactura));
            Sar_Fcrmvh.Add("USR_FCRMVH_IDPAGO", FormatStringSql(facturas.IdPago));
            Sar_Fcrmvh.Add("USR_FCRMVH_IDCOMP", FormatStringSql(facturas.IdCompra));


            Sar_Fcrmvh.Add("SAR_FC_FECALT", "GETDATE()");
            Sar_Fcrmvh.Add("SAR_FC_FECMOD", "GETDATE()");
            Sar_Fcrmvh.Add("SAR_FC_USERID", FormatStringSql("API"));
            Sar_Fcrmvh.Add("SAR_FC_ULTOPR", FormatStringSql("A"));
            Sar_Fcrmvh.Add("SAR_FC_DEBAJA", FormatStringSql("N"));
            Sar_Fcrmvh.Add("SAR_FC_OALIAS", FormatStringSql("SAR_FCRMVH"));

            Sar_Fcrmvh.Add("SAR_FCRMVI", facturas.Items);
            Sar_Fcrmvh.Add("SAR_FCRMVI07", facturas.Impuestos);

            return Sar_Fcrmvh;
        }

        public Dictionary<string, object> CreateDictionarySAR_FCRMVI(FacturasItemsDTO items, int idOperacion, int index)
        {
            Dictionary<string, object> Sar_Fcrmvi = new Dictionary<string, object>();

            Sar_Fcrmvi.Add("SAR_FCRMVI_IDENTI", FormatStringSql(idOperacion));
            Sar_Fcrmvi.Add("SAR_FCRMVI_NROITM", FormatStringSql(index));
            Sar_Fcrmvi.Add("SAR_FCRMVI_TIPCPT", FormatStringSql(items.TipoConcepto));
            Sar_Fcrmvi.Add("SAR_FCRMVI_CODCPT", FormatStringSql(items.Concepto));
            Sar_Fcrmvi.Add("SAR_FCRMVI_TIPPRO", FormatStringSql(items.TipoProducto));
            Sar_Fcrmvi.Add("SAR_FCRMVI_ARTCOD", FormatStringSql(items.Producto));
            Sar_Fcrmvi.Add("SAR_FCRMVI_PRECIO", items.Precio);
            Sar_Fcrmvi.Add("SAR_FCRMVI_CANTID", items.Cantidad);
            Sar_Fcrmvi.Add("SAR_FCRMVI_PCTBF1", items.Bonificacion1);
            Sar_Fcrmvi.Add("SAR_FCRMVI_PCTBF2", items.Bonificacion2);
            Sar_Fcrmvi.Add("SAR_FCRMVI_PCTBF3", items.Bonificacion3);
            Sar_Fcrmvi.Add("USR_FCRMVI_PCTBF4", items.Bonificacion4);
            Sar_Fcrmvi.Add("USR_FCRMVI_PCTBF5", items.Bonificacion5);
            Sar_Fcrmvi.Add("USR_FCRMVI_PCTBF6", items.Bonificacion6);
            Sar_Fcrmvi.Add("USR_FCRMVI_PCTBF7", items.Bonificacion7);
            Sar_Fcrmvi.Add("USR_FCRMVI_PCTBF8", items.Bonificacion8);
            Sar_Fcrmvi.Add("USR_FCRMVI_PCTBF9", items.Bonificacion9);
            Sar_Fcrmvi.Add("USR_FCRMVI_TEXTOS", FormatStringSql(items.Observaciones));
            Sar_Fcrmvi.Add("USR_FCRMVI_CNTBON", items.CantidadBonificada);
            Sar_Fcrmvi.Add("USR_FCRMVI_MODOTR", FormatStringSql(items.ModuloOTOriginal));
            Sar_Fcrmvi.Add("USR_FCRMVI_CODOTR", FormatStringSql(items.CodigoOTOriginal));
            Sar_Fcrmvi.Add("USR_FCRMVI_NROOTR", items.NumeroOTOriginal);
            Sar_Fcrmvi.Add("USR_FCRMVI_FCHOTR", FormatStringSql(items.FechaOTOriginal));
            Sar_Fcrmvi.Add("USR_FCRMVI_NROOC", FormatStringSql(items.NumeroOrdendeCompra));
            Sar_Fcrmvi.Add("USR_FCRMVI_NROITM", items.NumeroItemCustom);
            Sar_Fcrmvi.Add("USR_FCRMVI_IDCUST", FormatStringSql(items.IDCustom));
            Sar_Fcrmvi.Add("USR_FCRMVI_VNDDOR", FormatStringSql(items.Vendedor));
            Sar_Fcrmvi.Add("USR_FCRMVI_VNDDO2", FormatStringSql(items.Vendedor2));



            Sar_Fcrmvi.Add("SAR_FC_FECALT", "GETDATE()");
            Sar_Fcrmvi.Add("SAR_FC_FECMOD", "GETDATE()");
            Sar_Fcrmvi.Add("SAR_FC_USERID", FormatStringSql("API"));
            Sar_Fcrmvi.Add("SAR_FC_ULTOPR", FormatStringSql("A"));
            Sar_Fcrmvi.Add("SAR_FC_DEBAJA", FormatStringSql("N"));
            Sar_Fcrmvi.Add("SAR_FC_OALIAS", FormatStringSql("SAR_FCRMVI"));

            return Sar_Fcrmvi;
        }

        public Dictionary<string, object> CreateDictionarySAR_FCRMVI07(ImpuestosFacturasDTO impuestos, int idOperacion, int index)
        {
            Dictionary<string, object> Sar_Fcrmvi07 = new Dictionary<string, object>();

            Sar_Fcrmvi07.Add("SAR_FCRMVI07_IDENTI", FormatStringSql(idOperacion));
            Sar_Fcrmvi07.Add("SAR_FCRMVI07_NROITM", index);
            Sar_Fcrmvi07.Add("SAR_FCRMVI07_TIPCPT", FormatStringSql(impuestos.TipoConceptoImpuesto));
            Sar_Fcrmvi07.Add("SAR_FCRMVI07_CODCPT", FormatStringSql(impuestos.CodigoConceptoImpuesto));
            Sar_Fcrmvi07.Add("SAR_FCRMVI07_IMPGRA", impuestos.ImporteGravado);
            Sar_Fcrmvi07.Add("SAR_FCRMVI07_PORCEN", impuestos.Tasa);
            Sar_Fcrmvi07.Add("SAR_FCRMVI07_INGRES", impuestos.ImporteImpuesto);

            Sar_Fcrmvi07.Add("SAR_FC_FECALT", "GETDATE()");
            Sar_Fcrmvi07.Add("SAR_FC_FECMOD", "GETDATE()");
            Sar_Fcrmvi07.Add("SAR_FC_USERID", FormatStringSql("API"));
            Sar_Fcrmvi07.Add("SAR_FC_ULTOPR", FormatStringSql("A"));
            Sar_Fcrmvi07.Add("SAR_FC_DEBAJA", FormatStringSql("N"));
            Sar_Fcrmvi07.Add("SAR_FC_OALIAS", FormatStringSql("SAR_FCRMVI"));


            return Sar_Fcrmvi07;
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
