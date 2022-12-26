using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class AplicacionesDTO
    {
        public string CodigoFormularioAplicacion { get; set; }
        public int? NumeroFormularioAplicacion { get; set; }
        public int? Cuota { get; set; }
        public decimal? ImporteNacionalAplicado { get; set; }
        public decimal? DescuentoRecargo { get; set; }
        public string Moneda { get; set; }
        public decimal? ImporteExtranjeraAplicado { get; set; }
        public decimal? PorcentajeDescuentoRecargo1 { get; set; }
        public decimal? PorcentajeDescuentoRecargo2 { get; set; }
        public decimal? PorcentajeDescuentoRecargo3 { get; set; }

    }
}
