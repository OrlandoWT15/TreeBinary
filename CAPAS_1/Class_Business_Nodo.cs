using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emtity;
using System.Data;

namespace CAPAS_1
{
    public class Class_Business_Nodo
    {
        private Class_DAL_Nodo llave_Business = new Class_DAL_Nodo();

        public string AgregarINE(Class_Emtity_INE objNuevo)
        {
            return llave_Business.AgregarNodo(objNuevo);
        }

        public Class_Emtity_INE[] MostrarPreOrdenPrueba()
        {
            Class_Emtity_INE[] almacenEx = new Class_Emtity_INE[llave_Business.marcador];
            llave_Business.marcadorPreO = 0;
            llave_Business.PreOrdenNodoPrueba(ref almacenEx);
            return almacenEx;
        }

        public Class_Emtity_INE[] MostrarInOrdenPrueba()
        {
            Class_Emtity_INE[] almacenEx = new Class_Emtity_INE[llave_Business.marcador];
            llave_Business.marcadorInO = 0;
            llave_Business.InOrdenNodoPrueba(ref almacenEx);
            return almacenEx;
        }
        public Class_Emtity_INE[] MostrarPostOrdenPrueba()
        {
            Class_Emtity_INE[] almacenEx = new Class_Emtity_INE[llave_Business.marcador];
            llave_Business.marcadorPostO = 0;
            llave_Business.PostOrdenNodoPrueba(ref almacenEx);
            return almacenEx;
        }

        public Class_Emtity_INE BuscarINE(ref string mensaje, string curp)
        {
            return llave_Business.BuscarNodo_Prueba(ref mensaje, curp);
        }

        public string EliminarINE(string curp)
        {
            return llave_Business.EliminarNodoPrueba(curp);
        }

        public DataTable GuardarXMLINE(DataTable table)
        {
            return llave_Business.GuardarXML(table);
        }
    }
}
