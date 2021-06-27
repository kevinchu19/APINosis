using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNosis.Models
{
    public class FacturasItemsDTO
    {
        public string TipoConcepto { get; set; }
        public string Concepto { get; set; }
        public string TipoProducto { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Bonificacion1 { get; set; }
        public decimal Bonificacion2 { get; set; }
        public decimal Bonificacion3 { get; set; }
        public decimal Bonificacion4 { get; set; }
        public decimal Bonificacion5 { get; set; }
        public decimal Bonificacion6 { get; set; }
        public decimal Bonificacion7 { get; set; }
        public decimal Bonificacion8 { get; set; }
        public decimal Bonificacion9 { get; set; }
        public string Observaciones { get; set; }
        public decimal CantidadBonificada { get; set; }
        public string ModuloOTOriginal { get; set; }
        public string CodigoOTOriginal { get; set; }
        public decimal NumeroOTOriginal { get; set; }
        public string FechaOTOriginal { get; set; }
        public string NumeroOrdendeCompra { get; set; }
        public int NumeroItemCustom { get; set; }
        public string IDCustom { get; set; }
        public string Vendedor { get; set; }
        public string Vendedor2 { get; set; }

    }
}
