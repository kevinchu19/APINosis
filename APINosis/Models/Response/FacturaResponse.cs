using APINosis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models.Response
{
    public class FacturaResponse : BaseResponse<ComprobanteGenerado>
    {
        
        public FacturaResponse(string titulo, int idOperacion, ComprobanteGenerado resource, string recurso) : base(titulo,idOperacion,resource, recurso) {}
        public FacturaResponse(string titulo, int idOperacion, string message) : base(titulo, idOperacion, message) { }

    }
}
