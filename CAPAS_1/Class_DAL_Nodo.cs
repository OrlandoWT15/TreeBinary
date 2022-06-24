using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emtity;
using System.Data;

namespace CAPAS_1
{
    public class Class_DAL_Nodo
    {
        private Class_Emtity_INE raiz = null;

        private DataSet almacenGrande = new DataSet();

        public int marcador { get; set; }

        



        /*Insertar*/
        public string AgregarNodo(Class_Emtity_INE nuevonodo)
        {
            string mensaje = "";
            if (nuevonodo != null)
            {
                if (Agregar(ref raiz, nuevonodo))
                {
                    mensaje = "Se agrego un Nuevo nodo";
                }
                else
                {
                    mensaje = "Algo salio mal intentalo de nuevo";
                }
            }
            return mensaje;
        }
        private Boolean Agregar(ref Class_Emtity_INE ancla, Class_Emtity_INE nuevo)
        {
            Boolean salida = false;
            Class_Emtity_INE nivel = null;
            Class_Emtity_INE profundidad = null;

            profundidad = ancla;
            while (profundidad != null)
            {
                nivel = profundidad;
                if (String.Compare(nuevo.Curp, profundidad.Curp) < 0)
                {
                    profundidad = profundidad.nodoIzq;
                }
                else
                {
                    if (String.Compare(nuevo.Curp,profundidad.Curp) > 0)
                    {
                        profundidad = profundidad.nodoDer;
                    }
                    else if (String.Compare(nuevo.Curp, nivel.Curp) == 0)
                    {
                        profundidad = null;
                    }
                }
            }

            nuevo.nodoPadre = nivel;

            if (nivel == null)
            {
                ancla = nuevo;
                salida = true;
            }
            else
            {
                if (String.Compare(nuevo.Curp, nivel.Curp) < 0)
                {
                    nivel.nodoIzq = nuevo;
                    salida = true;
                }
                else
                {
                    if (String.Compare(nuevo.Curp, nivel.Curp) > 0)
                    {
                        nivel.nodoDer = nuevo;
                        salida = true;
                    }
                    else if(String.Compare(nuevo.Curp, nivel.Curp) == 0)
                    {
                        salida = false;
                    }
                }
            }

            marcador++;
            return salida;

        }
        /*END---Insertar*/

        /*--Mostrar--*/
        /*PRE-ORDEN*/
        public int marcadorPreO = 0;
        public void PreOrdenNodoPrueba(ref Class_Emtity_INE[] almacenExterno)
        {
            PreOrdenPrueba(raiz, ref almacenExterno);
        }

        private void PreOrdenPrueba(Class_Emtity_INE ancla, ref Class_Emtity_INE[] almacen)
        {
            if (ancla != null)
            {
                almacen[marcadorPreO] = ancla;
                marcadorPreO++;
                PreOrdenPrueba(ancla.nodoIzq, ref almacen);
                PreOrdenPrueba(ancla.nodoDer, ref almacen);
            }
        }
        /*END---PRE-ORDEN*/
        /*IN-ORDEN*/
        public int marcadorInO = 0;
        public void InOrdenNodoPrueba(ref Class_Emtity_INE[] almacenExterno)
        {
            InOrdenPrueba(raiz, ref almacenExterno);
        }

        private void InOrdenPrueba(Class_Emtity_INE ancla, ref Class_Emtity_INE[] almacen)
        {
            if (ancla != null)
            {
                InOrdenPrueba(ancla.nodoIzq, ref almacen);

                almacen[marcadorInO] = ancla;
                marcadorInO++;

                InOrdenPrueba(ancla.nodoDer, ref almacen);
            }
        }
        /*END---IN-ORDEN*/
        /*POST-ORDEN*/
        public int marcadorPostO = 0;
        public void PostOrdenNodoPrueba(ref Class_Emtity_INE[] almacenExterno)
        {
            PostdenPrueba(raiz, ref almacenExterno);
        }

        private void PostdenPrueba(Class_Emtity_INE ancla, ref Class_Emtity_INE[] almacen)
        {
            if (ancla != null)
            {
                PostdenPrueba(ancla.nodoIzq, ref almacen);
                PostdenPrueba(ancla.nodoDer, ref almacen);

                almacen[marcadorPostO] = ancla;
                marcadorPostO++;
            }
        }
        /*END---IN-ORDEN*/
        /*END---Mostrar*/

        /*Buscar*/
        public Class_Emtity_INE BuscarNodo_Prueba(ref string salida, string curp)
        {
            Class_Emtity_INE encontrado = null;

            salida = " Lo sentimos la busqueda fue un fracaso vuelve a intentarlo";
            encontrado = BuscarNodoPrueba(raiz, curp);
            if (encontrado != null)
            {
                salida = " Busqueda finalizada" + " | " + encontrado.Curp;
            }
            return encontrado;
        }
        private Class_Emtity_INE BuscarNodoPrueba(Class_Emtity_INE busqueda, string curp)
        {
            if (busqueda == null)
            {
                return null;
            }
            else
            {
                if (curp.CompareTo(busqueda.Curp) < 0)
                {
                    return BuscarNodoPrueba(busqueda.nodoIzq, curp);
                }

                if (curp.CompareTo(busqueda.Curp) > 0)
                {
                    return BuscarNodoPrueba(busqueda.nodoDer, curp);
                }
            }
            return busqueda;
        }
        /*END---Buscar*/

        /*Eliminar*/
        public string EliminarNodoPrueba(string curp)
        {
            Class_Emtity_INE encontrado = BuscarNodoPrueba(raiz, curp);
            if (encontrado != null)
            {
                return Eliminar(encontrado);
            }
            else
            {
                return "Elemento no encontrado";
            }
        }
        private string Eliminar(Class_Emtity_INE pArranque)
        {
            Class_Emtity_INE temporalDelet = pArranque;
            Class_Emtity_INE temporalPadre = null;
            Class_Emtity_INE temporalChild = null;

            if (temporalDelet != null)
            {
                Class_Emtity_INE parent = findParent(pArranque, pArranque.Curp);

                if (temporalDelet.nodoIzq == null && temporalDelet.nodoDer == null)//hoja
                {
                    temporalPadre = temporalDelet.nodoPadre;

                    if (temporalPadre == temporalDelet.nodoIzq)
                    {
                        temporalPadre.nodoIzq = null;
                    }
                    else
                    {
                        temporalPadre.nodoDer = null;
                    }
                }
                else
                {
                    if (temporalDelet.nodoIzq == null || temporalDelet.nodoDer == null)//un hijo
                    {
                        temporalChild = temporalDelet.nodoIzq == null ? temporalDelet.nodoDer : temporalDelet.nodoIzq;

                        temporalPadre = temporalDelet.nodoPadre;

                        if (temporalDelet == temporalPadre.nodoIzq)
                        {
                            temporalPadre.nodoIzq = temporalChild;
                        }
                        else
                        {
                            temporalPadre.nodoDer = temporalChild;
                        }
                    }
                    else//dos hijos
                    {
                        if (temporalDelet.nodoIzq != null || temporalDelet.nodoDer != null)
                        {
                            Class_Emtity_INE processed = BuscarMin(pArranque);

                            temporalDelet.Curp = processed.Curp;
                            temporalDelet.Nombre = processed.Nombre;
                            temporalDelet.Domicilio = processed.Domicilio;
                            temporalDelet.Estado = processed.Estado;
                            temporalDelet.Municipio = processed.Municipio;
                            temporalDelet.Seccion = processed.Seccion;
                            temporalDelet.Vigencia = processed.Vigencia;

                            processed = null;
                        }
                    }
                }
                return pArranque.Curp + " Eliminado";
            }
            else
            {
                return "Fallos al eliminar el elemento";
            }
        }
        public Class_Emtity_INE findParent(Class_Emtity_INE root, string curp)
        {
            if (root.nodoIzq == null || root.nodoDer == null)
            {
                return root;
            }
            else if (curp.CompareTo( root.Curp) < 0)
            {
                return this.findParent(root.nodoIzq, curp);
            }
            else
            {
                return this.findParent(root.nodoDer, curp);
            }
        }
        private Class_Emtity_INE BuscarMin(Class_Emtity_INE pArranque)
        {
            Class_Emtity_INE encontrado = null;
            if(pArranque != null)
            {
                if (pArranque.nodoIzq == null)
                    encontrado = pArranque;
                else
                    encontrado = BuscarMin(pArranque.nodoIzq);
            }
            return encontrado;    
        }
        /*END---Eliminar*/

        /*Guardar*/
        public DataTable GuardarXML(DataTable almacenExXML)
        {
            if (Guardar( ref almacenExXML))
            {
                return almacenExXML;
            }
            return null;
        }

        private void RecorridoAmplitud(ref List<Class_Emtity_INE> listaOrden, Class_Emtity_INE ancla )
        {
            listaOrden = new List<Class_Emtity_INE>();
            Class_Emtity_INE refAncla = null;

            Queue<Class_Emtity_INE> PrimeraCola = new Queue<Class_Emtity_INE>();
            refAncla = ancla;
            if (refAncla != null)
            {
                PrimeraCola.Enqueue(refAncla);
            }
            while (PrimeraCola.Count > 0)
            {
                refAncla = PrimeraCola.Dequeue();
                listaOrden.Add(refAncla);
                if (refAncla.nodoIzq != null)
                {
                    PrimeraCola.Enqueue(refAncla.nodoIzq);
                }
                if (refAncla.nodoDer != null)
                {
                    PrimeraCola.Enqueue(refAncla.nodoDer);
                }
            }
        }

        private Boolean Guardar(ref DataTable alamcenXml)
        {
            string dato = "";
            List<Class_Emtity_INE> atrapaList = null;
            int t = 0;
            

            RecorridoAmplitud(ref atrapaList, raiz);

            if (atrapaList != null)
            {
                alamcenXml = new DataTable("XMLGuardar");
                alamcenXml.Columns.Add("Curp", dato.GetType());
                alamcenXml.Columns.Add("Nombre", dato.GetType());
                alamcenXml.Columns.Add("Domicilio", dato.GetType());
                alamcenXml.Columns.Add("Estado", dato.GetType());
                alamcenXml.Columns.Add("Municipio", dato.GetType());
                alamcenXml.Columns.Add("Seccion", dato.GetType());
                alamcenXml.Columns.Add("Vigencia", dato.GetType());

                foreach (Class_Emtity_INE i in atrapaList)
                {
                    DataRow row = alamcenXml.NewRow();
                    row[0] = i.Curp;
                    row[1] = i.Nombre;
                    row[2] = i.Domicilio;
                    row[3] = i.Estado;
                    row[4] = i.Municipio;
                    row[5] = i.Seccion;
                    row[6] = i.Vigencia;

                    alamcenXml.Rows.Add(row);
                }
                return true;
            }
            return false;
        }
        /*END---Guardar*/
    }
}
