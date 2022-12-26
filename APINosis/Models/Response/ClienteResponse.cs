
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models.Response
{
    public class ClienteResponse : BaseResponse<VtmclhDTO>
    {
        public override bool ShouldSerializeComprobanteGenerado()
        {
            return (ComprobanteGenerado != null);
        }

        public ClienteResponse(string titulo, int idOperacion, VtmclhDTO resource, string recurso) : base(titulo,idOperacion,resource, recurso) {}
        public ClienteResponse(string titulo, int idOperacion, string message) : base(titulo, idOperacion, message) { }

        
    }
}
