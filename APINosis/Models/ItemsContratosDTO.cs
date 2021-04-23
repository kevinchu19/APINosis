using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNosis.Models
{
    public class ItemsContratosDTO
    {
        public int Numerodeitem { get; set; }
        public string Tipodeproducto { get; set; }
        public string Codigodeproducto { get; set; }
        public string TextoAdicional { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public string TrabajaConVigencia { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string Preciosvigentesalfacturar { get; set; }
        public string Vendedor { get; set; }
        public string Vendedor2 { get; set; }
        public string ModuloOrdendeTrabajo { get; set; }
        public string CodigoOrdendeTrabajo { get; set; }
        public int NumeroOrdendeTrabajo { get; set; }
        public DateTime FechadeMovimiento { get; set; }
        public string ModulodeOTModificacion { get; set; }
        public DateTime FechadeComision { get; set; }
        public string CodigodeOTModificacion { get; set; }
        public int NumerodeOTModificacion { get; set; }
        public DateTime FechadeOTModificacion { get; set; }
        public int NumerodeOrdendecompra { get; set; }
        public string ArchivodeExportacion { get; set; }
        public string IDCustom { get; set; }
        public int NumerodeRegistroExpo { get; set; }
        public DateTime FechadeExportacion { get; set; }
    }
}
