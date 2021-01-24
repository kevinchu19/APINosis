using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace APINosis.OE
{
    public class Translate
    {
        private object oTranslate { get; set; }
        private Type TRType{ get; set; }
        public Translate()
        {
            TRType = Type.GetTypeFromProgID("GRWTranslate.GRWTraducciones");
            oTranslate = Activator.CreateInstance(TRType);
            TRType.InvokeMember("DatabasePath", BindingFlags.SetProperty, null, oTranslate, new object[] { "C:\\Program Files (x86)\\Softland\\Cliente\\Language\\Languaje.mdb" });
        }

        public string traducir(string error)
        {
            return (string)TRType.InvokeMember("Translate", BindingFlags.InvokeMethod, null, oTranslate, new object[] { error });
        }
    }
}
