using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class ClienteDTO
    {
        public int IdOperacion { get; set; }
        public string NumeroCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NumeroSubcuenta { get; set; }
        public string DireccionFiscal { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }
        public string SituacionFrenteAlIVA { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Vendedor { get; set; }
        public string Cobrador { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Zona { get; set; }
        public string Actividad { get; set; }
        public string Categoria { get; set; }
        public string CondicionDePago { get; set; }
        public string ListaPrecios { get; set; }
        public string DireccionEntrega { get; set; }
        public string PaisEntrega { get; set; }
        public string CodigoPostalEntrega { get; set; }
        public string ProvinciaEntrega { get; set; }
        public string LocalidadEntrega { get; set; }
        public string TipoDocumento1 { get; set; }
        public string TipoDocumento2 { get; set; }
        public string TipoDocumento3 { get; set; }
        public string NumeroDocumento1 { get; set; }
        public string NumeroDocumento2 { get; set; }
        public string NumeroDocumento3 { get; set; }
        public string TipodePersona { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Activadora { get; set; }
        public string ModalidadPago { get; set; }
        public string EmailFacturas { get; set; }
        public string EmailRecibos { get; set; }
        public string EnviaMail { get; set; }
        public string FechaCambioRazonSocial { get; set; }
        public string IdiomaReferencia { get; set; }
        public List<ContactosDTO> Contactos { get; set; }

        public List<ImpuestosDTO> Impuestos{ get; set; }

    }
}
