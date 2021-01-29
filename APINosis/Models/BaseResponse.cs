using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Models
{
    public abstract class BaseResponse<T>
    {

        public int IdOperacion { get; set; }
        public int Estado { get; set; }
        public string Titulo { get; set; }
        public string Mensaje{ get; set; }
        
        protected BaseResponse(string titulo, int idOperacion, T resource)
        {
            Estado  = 200;
            Mensaje = "Cliente generado con éxito";
            Titulo = titulo;
            IdOperacion = idOperacion;
        }

        protected BaseResponse(string titulo, int idOperacion,string message)
        {
            Estado = 400;
            Mensaje = message;
            Titulo = titulo;
            IdOperacion = idOperacion;
        }
    }
}
