using APINosis.Interfaces;
using APINosis.Models;
using APINosis.Models.Response;
using System;
using System.Reflection;


namespace APINosis.OE
{
    public class VT_TT_VTRMVH_ANU : OEBase, IOEObject
    {
        public VT_TT_VTRMVH_ANU(string user, string password, string companyName, string pathLanguage) :
            base(user, password, companyName, pathLanguage) //NO AGREGAR DEPENDENCIAS A OTROS SERVICIOS
        { }

        public void instancioObjeto(string tipoOperacion)
        {
            object[] objetoSoftland = new object[] { "VTCANUWIZ", 6, tipoOperacion };
            oWizard = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, oCompany, objetoSoftland);

        }

        public void MoveNext()
        {
            OEType.InvokeMember("MoveNext", BindingFlags.InvokeMethod, null, oWizard, null);        
        }

        public Save Finish()
        {
            OEType.InvokeMember("Finish", BindingFlags.InvokeMethod, null, oWizard, null);

            string[] sErrorMessage = new string[] { null };
            bool finished = (bool)OEType.InvokeMember("Finished", BindingFlags.GetProperty, null, oWizard, null);

            Translate oTranslate = new Translate(_pathLanguage);

            if (finished == false && sErrorMessage[0] == null)
            {
                int messageCount = (int)OEType.InvokeMember("MessageCount", BindingFlags.GetProperty, null, oWizard, null);
                int i;
                for (i = messageCount; i >= 1; i--)
                {
                    dynamic oMessages = OEType.InvokeMember("Messages", BindingFlags.GetProperty, null, oWizard, new object[] { i });
                    string description = (string)OEType.InvokeMember("Description", BindingFlags.GetProperty, null, oMessages, null);
                    if (description != "")
                    {
                        sErrorMessage[0] = oTranslate.traducir(description);
                        break;
                    }
                }
            }

            this.closeObjectInstance();

            return new Save
            {
                Result = finished,
                errorMessage = sErrorMessage[0],
                ComprobanteGenerado = null
            };





        }



    }
}