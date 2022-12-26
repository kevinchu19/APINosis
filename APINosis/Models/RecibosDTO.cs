using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class RecibosDTO
    {
        public int IdOperacion { get; set; }

        public string TipoMovimiento { get; set; }
        public string CodigoReciboAnular { get; set; }
        public int? NumeroReciboAnular { get; set; }
        public string CodigoRecibo { get; set; }
        public int? NumeroRecibo { get; set; }
        public string CodigoComprobanteAnulacion{ get; set; }
        public int? NumeroComprobanteAnulacion { get; set; }

        public string CodigoComprobanteAGenerar { get; set; }
        public string Cliente { get; set; }
        public string FechaContable { get; set; }
        public string Cobrador { get; set; }
        public string Observacion { get; set; }
        public string CodigoSubcuenta { get; set; }
        public string FechaParidades { get; set; }
        public string UtilizaParidadesOriginales { get; set; }
        public string FechaDebito { get; set; }

        public List<AplicacionesDTO> Aplicaciones { get; set; }
        public List<MediosDeCobroDTO> MediosDeCobro { get; set; }

    }
}
