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

        public ContratoResponse(string titulo, int idOperacion) : base(titulo, idOperacion) { }
        public ContratoResponse(string titulo, int idOperacion, Cvmcth resource) : base(titulo,idOperacion,resource) {}
        public ContratoResponse(string titulo, int idOperacion, string message) : base(titulo, idOperacion, message) { }

        
    }
}
