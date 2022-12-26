using APINosis.Entities;
using APINosis.Helpers;
using APINosis.Interfaces;
using APINosis.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace APINosis.OE
{
    public class CV_RR_CVMCTH: OEBase, IOEObject
    {
        
        public CV_RR_CVMCTH(string user, string password, string companyName, string pathLanguage): 
            base(user, password, companyName, pathLanguage) //NO AGREGAR DEPENDENCIAS A OTROS SERVICIOS
        {}

        public void instancioObjeto(string tipoOperacion)
        {
            object[] objetoSoftland = new object[] { "CVMCTH01", 4, tipoOperacion};
            oInstance = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, oCompany, objetoSoftland);
                
        }



        

        
    }
}