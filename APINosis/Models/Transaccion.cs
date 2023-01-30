using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class Transaccion
    {
        public string idOperacion { get; set; }
        public string Estado { get; set; }
        public object RegistracionGenerada { get; } = null;
        public string MensajeError { get; set; } = null;

        public Transaccion(string _idOperacion , string _estado , string _mensajeError )
        {
            idOperacion = _idOperacion;
            Estado = _estado;
            MensajeError = _mensajeError;
        }

        public Transaccion(string _idOperacion, string _estado, object _registracionGenerada)
        {
            idOperacion = _idOperacion;
            Estado = _estado;
            RegistracionGenerada = _registracionGenerada;
        }
    }
}
