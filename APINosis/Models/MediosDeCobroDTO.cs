using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class MediosDeCobroDTO
    {
        public string TipoConcepto { get; set; }
        public string CodigoConcepto { get; set; }
        public int? Cheque { get; set; }
        public int? SucursalCheque { get; set; }
        public string CodigoBancoCheque { get; set; }
        public string FechaVencimientoCheque { get; set; }
        public string CategoriaCheque { get; set; }
        public decimal? ImporteNacional { get; set; }
        public decimal? TipoCambio { get; set; }
        public decimal? ImporteExtranjera { get; set; }
        public string FirmanteCheque { get; set; }
        public string Observaciones { get; set; }
        public string TipoDocumentoCheque { get; set; }
        public string NumeroDocumentoCheque { get; set; }
        public string EstructuraComprobanteOriginal { get; set; }
        public string CodigoOriginal { get; set; }
        public string CuentaCorriente { get; set; }
        public string Titular { get; set; }
        public string NumerodeTC { get; set; }
        public string CodigodeAutorizacionTarjetasIDPaypal { get; set; }
        public string FechaCobranza { get; set; }
        public int? NumeroLote { get; set; }
        public int? NumeroCupon { get; set; }
        public int? Cuotas { get; set; }
        public string FechaOperacion { get; set; }
        public string CodigoEstablecimiento { get; set; }
        public string IDCompra { get; set; }
        public string IDPago { get; set; }

    }
}
