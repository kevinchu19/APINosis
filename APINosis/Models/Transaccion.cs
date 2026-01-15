using APINosis.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class Transaccion
    {
        public string IdOperacion { get; set; }
        public string StatusProcesamiento { get; set; }
        public object Titulo { get; set; }
        public string Mensaje { get; set; } = null;
        public ComprobanteGenerado? ComprobanteGenerado { get; set; }

        public Transaccion(string _idOperacion , string _estado , string _titulo ,string _mensajeError, ComprobanteGenerado _comprobante)
        {
            IdOperacion = _idOperacion;
            StatusProcesamiento = _estado;
            Titulo = _titulo;
            Mensaje = _mensajeError;
            ComprobanteGenerado = _comprobante;
        }

        public Transaccion(string _idOperacion, string _estado, string _titulo, string _mensajeError)
        {
            IdOperacion = _idOperacion;
            StatusProcesamiento = _estado;
            Titulo = _titulo;
            Mensaje = _mensajeError;
        }

    }
}
