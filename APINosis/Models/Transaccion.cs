using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class Transaccion
    {
        public string IdOperacion { get; set; }
        public string Estado { get; set; }
        public object RegistracionGenerada { get; } = null;
        public string MensajeError { get; set; } = null;

        public Transaccion(string _idOperacion , string _estado , string _mensajeError )
        {
            IdOperacion = _idOperacion;
            Estado = _estado;
            MensajeError = _mensajeError;
        }

        public Transaccion(string _idOperacion, string _estado, object _registracionGenerada)
        {
            IdOperacion = _idOperacion;
            Estado = _estado;
            RegistracionGenerada = _registracionGenerada;
        }
    }
}
