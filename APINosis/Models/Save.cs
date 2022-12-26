using APINosis.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class Save
    {
        public bool Result { get; set; }
        public string errorMessage{ get; set; }
        public ComprobanteGenerado ComprobanteGenerado { get; set; }
    }
}
