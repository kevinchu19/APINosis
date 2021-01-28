﻿using APINosis.Helpers;
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
    public class VT_TT_VTMCLH: IOEObject
    {
        private Type OEType { get; set; }
        private object OEInst { get; set; }
        private object oApplication { get; set; }
        private object oCompany { get; set; }
        private object oInstance { get; set; }
        private object oTable { get; set; }
        private object oRow { get; set; }
        private object oField { get; set; }
        
        public VT_TT_VTMCLH(string user, string password, string companyName) //NO AGREGAR DEPENDENCIAS A OTROS SERVICIOS
        {
            OEType = Type.GetTypeFromProgID("cwlwoe.global");
            OEInst = Activator.CreateInstance(OEType);
            string[] userPassword = new string[] { user, password };
            object[] company = new string[] { companyName };

            oApplication = OEType.InvokeMember("GetApplication", BindingFlags.InvokeMethod, null, OEInst, userPassword);
            oCompany = OEType.InvokeMember("Companies", BindingFlags.GetProperty, null, oApplication, company);
            object[] objetoSoftland = new object[] { "VTMCLH", 4, "NEW" };
            oInstance = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, oCompany, objetoSoftland);
        }

        public void instancioObjeto(string user, string password, string companyName)
        {
            
        }

        public void asignoValor(string table, string field, string value, int deepnessLevel)
        {
            
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

            oField = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oRow, new object[] { field });

            if (value != "null" && value != "NULL" && value != null)
            {
                try
                {
                    if ((bool)OEType.InvokeMember("Readonly", BindingFlags.GetProperty, null, oField, null) == false)
                    {
                        if ((int)OEType.InvokeMember("DataType", BindingFlags.GetProperty, null, oField, null) == 8)
                        {
                            DateTime dateValue = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            value = dateValue.ToString("yyyyMMdd");
                        }

                        OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { value });

                    };

                }
                catch (Exception e)
                {
                    throw new BadRequestException($"Error al completar el campo {field} con el valor {value}: {e.InnerException.Message}");
                }
            }
            

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
                for (i = messageCount; i >= 1 ; i--)
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
    }
}