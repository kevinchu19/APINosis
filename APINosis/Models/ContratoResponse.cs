using APINosis.Entities;
using OE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class ContratoResponse : BaseResponse<Cvmcth>
    {

        public ContratoResponse(string titulo, int idOperacion, Cvmcth resource, string recurso) : base(titulo,idOperacion,resource, recurso) {}
        public ContratoResponse(string titulo, int idOperacion, string message) : base(titulo, idOperacion, message) { }

        
    }
}
