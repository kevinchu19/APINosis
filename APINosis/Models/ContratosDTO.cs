using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNosis.Models
{
    public class ContratosDTO
    {
        public int IdOperacion { get; set; }
        public string TipoContrato { get; set; }
        public string CodigoContrato { get; set; }
        public int Extension { get; set; }
        public string Descripcion { get; set; }
        public string Cliente { get; set; }
        public string CodigoDeSubcuenta { get; set; }
        public string CondicionDePago { get; set; }
        public string Vendedor { get; set; }
        public string Contratista { get; set; }
        public string ComprobanteVentas { get; set; }
        public string Del { get; set; }
        public string EmisionDela1raFactura { get; set; }
        public string UltimaFacturaAEmitir { get; set; }
        public string ListaDePrecios { get; set; }
        public string MonedaEmision { get; set; }
        public string PreciosVigentesAlFacturar { get; set; }
        public string Observaciones { get; set; }
        public string Facturacion { get; set; }
        public string RecuperaItemsEnNovedades { get; set; }
        public string TipodeExportacion { get; set; }
        public string CondicionComercial { get; set; }
        public string ModalidadDePago { get; set; }
        public string IdDeCompra { get; set; }
        public List<ItemsContratosDTO> Items { get; set; } = new List<ItemsContratosDTO>();
    }
}
