using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emtity
{
    public class Class_Emtity_INE
    {
        public Class_Emtity_INE nodoIzq = null;

        public Class_Emtity_INE nodoDer = null;

        public Class_Emtity_INE nodoPadre = null;



        public string Curp { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Seccion { get; set; }
        public string Vigencia { get; set; }


        //Constructor con objetos
        public Class_Emtity_INE(string curp, string nombre, string domicilio, string estado, string municipio, string seccion, string vigencia)
        {
            Curp = curp;
            Nombre = nombre;
            Domicilio = domicilio;
            Estado = estado;
            Municipio = municipio;
            Seccion = seccion;
            Vigencia = vigencia;
            nodoIzq = null;
            nodoDer = null;
            nodoPadre = null;
        }


        //Mostrar datos
        public string MostrarDatos()
        {
            string mensaje;
            return mensaje = "---------Credencial de Elector--------" + "\n" +
                "Nombre: " + Nombre + "\n" +
                "Curp: " + Curp + "\n" +
                "Domicilio: " + Domicilio + "\n" +
                "Estado: " + Estado + " Municipio: " + Municipio + " Seccion: " + Seccion + " Vigencia: " + Vigencia;
        }
    }
}
