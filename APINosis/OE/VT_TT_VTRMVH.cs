using APINosis.Interfaces;
using System.Reflection;


namespace APINosis.OE
{
    public class VT_TT_VTRMVH : OEBase, IOEObject
    {

        public VT_TT_VTRMVH(string user, string password, string companyName, string pathLanguage) :
            base(user, password, companyName, pathLanguage) //NO AGREGAR DEPENDENCIAS A OTROS SERVICIOS
        { }

        public void instancioObjeto(string tipoOperacion)
        {
            object[] objetoSoftland = new object[] { "VTRRCH", 4, tipoOperacion };
            oWizard = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, oCompany, objetoSoftland);

        }

        public void MoveNext()
        {
            OEType.InvokeMember("MoveNext", BindingFlags.InvokeMethod, null, oWizard, null);
            oInstance = OEType.InvokeMember("NextObject", BindingFlags.GetProperty, null, oWizard, null);
        }


    }

}