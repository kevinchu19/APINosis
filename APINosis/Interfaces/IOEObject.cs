using APINosis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Interfaces
{
    public interface IOEObject
    {
       
        public Save save()
        {
            return new Save
            {
                Result = true,
                errorMessage = ""
            };
        }

        public void asignoValor(string table, string field, string value, int deepnessLevel)
        {

        }

        public void closeObjectInstance()
        {

        }
    }
}
