using OE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class ClienteResponse : BaseResponse<VtmclhDTO>
    {
        public ClienteResponse(string titulo, int idOperacion, VtmclhDTO resource) : base(titulo,idOperacion,resource) {}
        public ClienteResponse(string titulo, int idOperacion, string message) : base(titulo, idOperacion, message) { }
        
    }
}
