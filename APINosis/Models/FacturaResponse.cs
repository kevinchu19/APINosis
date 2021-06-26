using APINosis.Entities;
using OE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class FacturaResponse : BaseResponse<Fcrmvh>
    {

        public FacturaResponse(string titulo, int idOperacion, Fcrmvh resource, string recurso) : base(titulo,idOperacion,resource, recurso) {}
        public FacturaResponse(string titulo, int idOperacion, string message) : base(titulo, idOperacion, message) { }

        
    }
}
