using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNosis.Models
{
    public class ContratosDTO
    {
        public int idOperacion { get; set; }
        public string TipoContrato { get; set; }
        public string CodigoContrato { get; set; }
        public int Extension { get; set; }
        public string Descripcion { get; set; }
        public string Cliente { get; set; }
        public string Codigodesubcuenta { get; set; }
        public string Condiciondepago { get; set; }
        public string Vendedor { get; set; }
        public string Contratista { get; set; }
        public string ComprobanteVentas { get; set; }
        public DateTime Del { get; set; }
        public DateTime Al { get; set; }
        public DateTime Emisiondela1rafactura { get; set; }
        public DateTime Ultimafacturaaemitir { get; set; }
        public string Listadeprecios { get; set; }
        public string MonedaEmision { get; set; }
        public string Preciosvigentesalfacturar { get; set; }
        public string Observaciones { get; set; }
        public string Facturacion { get; set; }
        public string RecuperaitemsenNovedades { get; set; }
        public string Tipodeexportacion { get; set; }
        public string Condicioncomercial { get; set; }
        public string ModalidaddePago { get; set; }
        public ItemsContratosDTO Items { get; set; }
    }
}
