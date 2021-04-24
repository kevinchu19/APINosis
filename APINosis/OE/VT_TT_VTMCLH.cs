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
    public class VT_TT_VTMCLH: OEBase, IOEObject
    {
        
        public VT_TT_VTMCLH(string user, string password, string companyName, string pathLanguage): 
            base(user, password, companyName, pathLanguage) //NO AGREGAR DEPENDENCIAS A OTROS SERVICIOS
        {}

        public void instancioObjeto(string tipoOperacion)
        {
            object[] objetoSoftland = new object[] { "VTMCLH", 4, tipoOperacion};
            oInstance = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, oCompany, objetoSoftland);
                
        }

        public void asignoaTM<T>(string table, string field, T valor, int deepnessLevel)
        {
            object value = new object();

            oRow = null;

            oTable = OEType.InvokeMember("Table", BindingFlags.GetProperty, null, oInstance, null);
            if (deepnessLevel == 1)
            {
                oRow = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
            }
            else
            {
                dynamic oTableHeader = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
                dynamic oTableGrid = OEType.InvokeMember("Tables", BindingFlags.GetProperty, null, oTableHeader, new object[] { table });
                dynamic oRows = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTableGrid, null);
                dynamic count = OEType.InvokeMember("Count", BindingFlags.GetProperty, null, oRows, null);
                
                oRow = OEType.InvokeMember("Add", BindingFlags.InvokeMethod, null, oRows, new object[] { (int)count + 1 });
            }


            switch (valor)
            {

                case VtmclcDTO:
                    VtmclcDTO contacto = (VtmclcDTO)(object) valor;
                    Type typeContacto = contacto.GetType();

                    System.Reflection.PropertyInfo[] listaPropiedades = typeContacto.GetProperties();

                    foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                    {
                        if (!campoAuditoria(propiedad.Name))
                        { 
                            oField = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oRow, new object[] { propiedad.Name });
                            value = (string)propiedad.GetValue(contacto, null);
                            resuelvoValor(oField, value);
                        }
                    }

                    break;

                default:
                    if (!campoAuditoria(field))
                    {
                        value = (string)(object)valor;
                        oField = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oRow, new object[] { field });
                        resuelvoValor(oField, value);
                    }

                    break;
            }


        }



        

        
    }
}