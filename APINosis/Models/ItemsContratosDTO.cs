using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNosis.Models
{
    public class ItemsContratosDTO
    {
        public int NumeroDeItem { get; set; }
        public string TipoDeProducto { get; set; }
        public string CodigoDeProducto { get; set; }
        public string TextoAdicional { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public string TrabajaConVigencia { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public string PreciosVigentesAlFacturar { get; set; }
        public string Vendedor { get; set; }
        public string Vendedor2 { get; set; }
        public string ModuloOrdenDeTrabajo { get; set; }
        public string CodigoOrdenDeTrabajo { get; set; }
        public int NumeroOrdenDeTrabajo { get; set; }
        public string FechaDeMovimiento { get; set; }
        public string ModulodeOTModificacion { get; set; }
        public string FechadeComision { get; set; }
        public string CodigodeOTModificacion { get; set; }
        public int NumerodeOTModificacion { get; set; }
        public string FechadeOTModificacion { get; set; }
        public string NumeroDeOrdenDeCompra { get; set; }
        public string ArchivoDeExportacion { get; set; }
        public string IdCustom { get; set; }
        public int NumeroDeRegistroExpo { get; set; }
        public string FechaDeExportacion { get; set; }
    }
}
