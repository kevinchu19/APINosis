using APINosis.Helpers;
using APINosis.Interfaces;
using APINosis.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace APINosis.OE
{
    public abstract class OEBase: IOEObject
    {
        protected Type OEType { get; set; }
        protected object OEInst { get; set; }
        protected object oApplication { get; set; }
        protected object oCompany { get; set; }
        protected object oInstance { get; set; }
        protected object oTable { get; set; }
        protected object oRow { get; set; }
        protected object oField { get; set; }

        public OEBase(string user, string password, string companyName)
        {
            OEType = Type.GetTypeFromProgID("cwlwoe.global");
            OEInst = Activator.CreateInstance(OEType);
            string[] userPassword = new string[] { user, password };
            object[] company = new string[] { companyName };

            oApplication = OEType.InvokeMember("GetApplication", BindingFlags.InvokeMethod, null, OEInst, userPassword);
            oCompany = OEType.InvokeMember("Companies", BindingFlags.GetProperty, null, oApplication, company);

        }

        public void limpioGrilla(string table)
        {
            dynamic oTableHeader = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
            dynamic oTableGrid = OEType.InvokeMember("Tables", BindingFlags.GetProperty, null, oTableHeader, new object[] { table });
            dynamic oRows = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTableGrid, null);
            //Limpio grilla
            OEType.InvokeMember("Clear", BindingFlags.InvokeMethod, null, oRows, null);
        }

        public void closeObjectInstance()
        {
            Marshal.ReleaseComObject(oField);
            Marshal.ReleaseComObject(oRow);
            Marshal.ReleaseComObject(oTable);
            Marshal.ReleaseComObject(oInstance);
            Marshal.ReleaseComObject(oApplication);
            Marshal.ReleaseComObject(oCompany);
            //OEType = null;
        }

        public Save save()
        {
            string[] sErrorMessage = new string[] { null };
            object result = OEType.InvokeMember("Save", BindingFlags.InvokeMethod, null, oInstance, sErrorMessage);

            if ((bool)result == false && sErrorMessage[0] == null)
            {
                int messageCount = (int)OEType.InvokeMember("MessageCount", BindingFlags.GetProperty, null, oInstance, null);
                int i = 0;
                for (i = messageCount; i >= 1; i--)
                {
                    dynamic oMessages = OEType.InvokeMember("Messages", BindingFlags.GetProperty, null, oInstance, new object[] { i });
                    string description = (string)OEType.InvokeMember("Description", BindingFlags.GetProperty, null, oMessages, null);
                    if (description != "")
                    {
                        //sErrorMessage[0] =  oTranslate.traducir(description);
                        sErrorMessage[0] = description;
                        break;
                    }
                }
            }

            this.closeObjectInstance();

            return new Save
            {
                Result = (bool)result,
                errorMessage = sErrorMessage[0]
            };


        }

        protected void resuelvoValor(dynamic oField, object value)
        {
            if ((string)value != "null" && (string)value != "NULL" && value != null)
            {
                try
                {
                    if ((bool)OEType.InvokeMember("Readonly", BindingFlags.GetProperty, null, oField, null) == false)
                    {
                        if ((int)OEType.InvokeMember("DataType", BindingFlags.GetProperty, null, oField, null) == 8)
                        {
                            DateTime dateValue = DateTime.ParseExact((string)value, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            value = dateValue.ToString("yyyyMMdd");
                        }

                        OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { value });

                    };

                }
                catch (Exception e)
                {
                    throw new BadRequestException($"Error al completar el campo {OEType.InvokeMember("Name", BindingFlags.GetProperty, null, oField, null)} con el valor {value}: {e.InnerException.Message}");
                }
            }
        }

    }
}
