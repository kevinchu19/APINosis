using APINosis.Models;
using APINosis.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNosis.Models
{
    public class FacturasDTO
    {
        public int IdOperacion { get; set; }
        public string CircuitoOrigen { get; set; }
        public string CircuitoAplicacion { get; set; }
        public string  CodigoComprobante { get; set; }
        public int NumeroComprobante { get; set; }
        public string ComprobanteVentas { get; set; }
        public string FechaContable { get; set; }
        public string Cliente { get; set; }
        public string CodigoSubcuenta { get; set; }
        public string DireccionEntrega { get; set; }
        public string PaisEntrega { get; set; }
        public string CodPosEntrega { get; set; }
        public string Vendedor { get; set; }
        public string CondicionPago { get; set; }
        public string ListaPrecios { get; set; }
        public string Texto { get; set; }
        public string CoeficienteDeuda { get; set; }
        public string CoeficienteEmision { get; set; }
        public string CoeficienteRegistracion { get; set; }
        public string Jurisdiccion { get; set; }
        public string TipoExportacion { get; set; }
        public string TipoDatoOpcionalAFIP { get; set; }
        public string ValorDatoOpcionalAFIP { get; set; }
        public string ModalidadPago { get; set; }
        public string LocalidadEntrega { get; set; }
        public string CodigoPostalExtendidoEntrega { get; set; }
        public string FechaFactura { get; set; }
        public string NumeroCAE { get; set; }
        public DateTime? VencimientoCAE { get; set; }

        public string IdPago { get; set; }
        public string IdCompra { get; set; }
        public List<FacturasItemsDTO> Items { get; set; } = new List<FacturasItemsDTO>();
        public List<ImpuestosComprobanteGenerado> ImpuestosFactura { get; set; } = new List<ImpuestosComprobanteGenerado>();
        public List<ImpuestosFacturasDTO> Impuestos { get; set; } = new List<ImpuestosFacturasDTO>();
        public decimal? ImporteTotal { get; set; }

    }
}
