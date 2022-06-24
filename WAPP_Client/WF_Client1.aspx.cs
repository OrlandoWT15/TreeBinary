using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using CAPAS_1;
using System.Data;


namespace WAPP_Client
{
    public partial class WF_Client1 : System.Web.UI.Page
    {
        private Class_Business_Nodo llaveBusinessNodo = new Class_Business_Nodo();
        private DataSet web = new DataSet();
        private string ruta = "~/Migrate/FormatoINE.xml";
        private string arrowInitial = "~/Resource/6137445_arrow_large_right_triangle_direction_icon.png";
        private string arrowOpen = "";
        private string arrowClose = "";
        string tipo, titulo;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["arrowOpen"] != null || Session["arrowClose"] != null || Session["llaveBusinessNodo"] != null)
            {
                llaveBusinessNodo = (Class_Business_Nodo)Session["llaveBusinessNodo"];
                arrowOpen = (string)Session["arrowOpen"];
                arrowClose = (string)Session["arrowClose"];
            }
            if(!IsPostBack)
            {
                clVigencia.Visible = false;
                btnBuscar.Enabled = false;
                btnEliminar.Enabled = false;
                ibtnInsert.ImageUrl = arrowInitial;
                ibtnSearch.ImageUrl = arrowInitial;
                ibtnDelete.ImageUrl = arrowInitial;
            }
        }

        //Herramientas
        protected void Limpiador()
        {
            if (txtVigencia.Text != "")
                txtVigencia.Text = "";
            if (txtCurp.Text !="")
                txtCurp.Text = "";
            if (txtNombre.Text != "")
                txtNombre.Text = "";
            if (txtDomicilio.Text != "")
                txtDomicilio.Text = "";
            if (txtEstado.Text != "")
                txtEstado.Text = "";
            if (txtMunicipio.Text != "")
                txtMunicipio.Text = "";
            if (txtSeccion.Text != "")
                txtSeccion.Text = "";

        }
        protected Boolean Validador()
        {
            if (txtVigencia.Text == "")
                return false;
            if (txtCurp.Text == "")
                return false;
            if (txtNombre.Text == "")
                return false;
            if (txtDomicilio.Text == "")
                return false;
            if (txtEstado.Text == "")
                return false;
            if (txtMunicipio.Text == "")
                return false;
            if (txtSeccion.Text == "")
                return false;
            else
                return true;
        }
        //end--herramientas

        //Calendario
        protected void imgCalendario_Click(object sender, ImageClickEventArgs e)
        {
            clVigencia.Visible = !clVigencia.Visible;
        }

        protected void clVigencia_SelectionChanged(object sender, EventArgs e)
        {
            clVigencia.Visible = false;
            txtVigencia.Text = clVigencia.SelectedDate.ToShortDateString();            
        }
        //end--calendario

        //Acciones
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            Boolean validador = false;

            validador = Validador();
            validador = true;
            if (validador)
            {
                mensaje = llaveBusinessNodo.AgregarINE(new Emtity.Class_Emtity_INE
                    (
                        txtCurp.Text,
                        txtNombre.Text,
                        txtDomicilio.Text,
                        txtEstado.Text,
                        txtMunicipio.Text,
                        txtSeccion.Text,
                        txtVigencia.Text
                    ));

                Session["llaveBusinessNodo"] = llaveBusinessNodo;

                if (mensaje.CompareTo("Algo salio mal intentalo de nuevo") == 0)
                {
                    tipo = "error";
                    titulo = "Lo sentimos";
                }
                else
                {
                    tipo = "success";
                    titulo = "Muy bien";
                }
                Limpiador();
            }
            else
            {
                tipo = "warning";
                titulo = "ups";
                mensaje = "Debes completar los campos";
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Insert",
            "swal('" + titulo + "!', '" + mensaje + "!', '" + tipo + "')", true);
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            Emtity.Class_Emtity_INE recupera = null;
            if (txtSearch.Text!="")
            {
                recupera = llaveBusinessNodo.BuscarINE(ref mensaje, txtSearch.Text);
                if(recupera!=null)
                {
                    tipo = "success";
                    titulo = "Felicidades !";
                    lbsArea.Items.Clear();
                    lbsArea2.Items.Clear();
                    lbsArea2.Items.Add("Curp :");
                    lbsArea2.Items.Add(recupera.Curp);
                    lbsArea2.Items.Add("Nombre :");
                    lbsArea2.Items.Add(recupera.Nombre);
                    lbsArea2.Items.Add("Domicilio :");
                    lbsArea2.Items.Add(recupera.Domicilio);
                    lbsArea2.Items.Add("Municipio :");
                    lbsArea2.Items.Add(recupera.Municipio);
                    lbsArea2.Items.Add("Sección :");
                    lbsArea2.Items.Add(recupera.Seccion);
                    lbsArea2.Items.Add("vigencia :");
                    lbsArea2.Items.Add(recupera.Vigencia);
                }
                else
                {
                    tipo = "warning";
                    titulo = "ups";
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert",
                "swal('" + titulo + "!', '" + mensaje + "!', '" + tipo + "')", true);
            }

        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (txtDelete.Text!="")
            {
                lbsArea.Items.Clear();
                lbsArea2.Items.Clear();
                mensaje = llaveBusinessNodo.EliminarINE(txtDelete.Text);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Eliminar",
                "swal('A tenciòn !', '" + mensaje + "!', 'info')", true);
            }
        }
        //end--Acciones

        //Arrows
        protected void ibtnInsert_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtnInsert.ImageUrl==arrowInitial)
            {
                arrowClose = "~/Resource/6137452_arrow_bottom_large_triangle_direction_icon.png";
                ibtnInsert.ImageUrl = arrowClose;
                Session["arrowClose"] = arrowClose;
                OcultarYver(0);
            }
            else
            {
                arrowOpen = "~/Resource/6137445_arrow_large_right_triangle_direction_icon.png";
                ibtnInsert.ImageUrl = arrowOpen;
                Session["arrowOpen"] = arrowOpen;
                OcultarYver(1);
            }
        }
        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtnDelete.ImageUrl == arrowInitial)
            {
                arrowClose = "~/Resource/6137452_arrow_bottom_large_triangle_direction_icon.png";
                ibtnDelete.ImageUrl = arrowClose;
                Session["arrowClose"] = arrowClose;
                OcultarYver(4);
            }
            else
            {
                arrowOpen = "~/Resource/6137445_arrow_large_right_triangle_direction_icon.png";
                ibtnDelete.ImageUrl = arrowOpen;
                Session["arrowOpen"] = arrowOpen;
                OcultarYver(5);
            }
        }
        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtnSearch.ImageUrl == arrowInitial)
            {
                arrowClose = "~/Resource/6137452_arrow_bottom_large_triangle_direction_icon.png";
                ibtnSearch.ImageUrl = arrowClose;
                Session["arrowClose"] = arrowClose;
                OcultarYver(2);
            }
            else
            {
                arrowOpen = "~/Resource/6137445_arrow_large_right_triangle_direction_icon.png";
                ibtnSearch.ImageUrl = arrowOpen;
                Session["arrowOpen"] = arrowOpen;
                OcultarYver(3);
            }
        }
        //end--Arrows

        //Verificacion de texto
        protected void txtDelete_TextChanged(object sender, EventArgs e)
        {
            if (txtDelete.Text !="")
            {
                btnEliminar.Enabled = true;
            }
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text!="")
            {
                btnBuscar.Enabled = true;
            }
        }

        //Mostrar
        protected void btnInorder_Click(object sender, EventArgs e)
        {
            Emtity.Class_Emtity_INE[] alamacenEx = null;
            alamacenEx = llaveBusinessNodo.MostrarInOrdenPrueba();
            lbsArea.Items.Clear();
            foreach (Emtity.Class_Emtity_INE i in alamacenEx)
            {
                lbsArea.Items.Add(i.Curp);
            }
        }

        protected void btnPreorder_Click(object sender, EventArgs e)
        {
            Emtity.Class_Emtity_INE[] alamacenEx = null;
            alamacenEx = llaveBusinessNodo.MostrarPreOrdenPrueba();
            lbsArea.Items.Clear();
            foreach (Emtity.Class_Emtity_INE i in alamacenEx)
            {
                lbsArea.Items.Add(i.Curp);
            }
        }

        protected void btnPostOrden_Click(object sender, EventArgs e)
        {
            Emtity.Class_Emtity_INE[] alamacenEx = null;
            alamacenEx = llaveBusinessNodo.MostrarPostOrdenPrueba();
            lbsArea.Items.Clear();
            foreach (Emtity.Class_Emtity_INE i in alamacenEx)
            {
                lbsArea.Items.Add(i.Curp);
            }

        }

        protected void lbsArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Emtity.Class_Emtity_INE busqueda = null;
            string mensaje = "";

            if (lbsArea.SelectedItem != null)
            {
                lbsArea2.Items.Clear();
                busqueda = llaveBusinessNodo.BuscarINE(ref mensaje, lbsArea.SelectedItem.Text);
                lbsArea2.Items.Add("Curp :");
                lbsArea2.Items.Add(busqueda.Curp);
                lbsArea2.Items.Add("Nombre :");
                lbsArea2.Items.Add(busqueda.Nombre);
                lbsArea2.Items.Add("Domicilio :");
                lbsArea2.Items.Add(busqueda.Domicilio);
                lbsArea2.Items.Add("Municipio :");
                lbsArea2.Items.Add(busqueda.Municipio);
                lbsArea2.Items.Add("Sección :");
                lbsArea2.Items.Add(busqueda.Seccion);
                lbsArea2.Items.Add("vigencia :");
                lbsArea2.Items.Add(busqueda.Vigencia);
            }
            
        }
        //Guardar en XML
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DataTable tablaG = null;
            

            tablaG = llaveBusinessNodo.GuardarXMLINE(tablaG);
            if (tablaG!=null)
            {
                web.Tables.Add(tablaG);
                web.WriteXml(Server.MapPath(ruta));
            }
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            List<Table> tableData = new List<Table>();
            string mensaje = "";
            Emtity.Class_Emtity_INE atrapa = null;

            foreach (DataTable i in web.Tables)
                i.BeginLoadData();

            web.ReadXml(Server.MapPath(ruta));
            if (web.Tables[0] != null)
            {
                gvXML.DataSource = web.Tables[0];//fill grid
                gvXML.DataBind();
                foreach (TableRow i in gvXML.Rows)
                {
                    atrapa = new Emtity.Class_Emtity_INE
                        (
                           curp: i.Cells[0].Text,
                           nombre: i.Cells[1].Text,
                           domicilio: i.Cells[2].Text,
                           estado: i.Cells[3].Text,
                           municipio: i.Cells[4].Text,
                           seccion: i.Cells[5].Text,
                           vigencia: i.Cells[6].Text
                        );
                    mensaje = llaveBusinessNodo.AgregarINE(atrapa);
                }
                if (mensaje.CompareTo("Algo salio mal intentalo de nuevo") == 0)
                {
                    tipo = "error";
                    titulo = "Lo sentimos";
                }
                else
                {
                    tipo = "success";
                    titulo = "Muy bien";
                    mensaje = "Se recuperaron los datos correctamente";
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Insert",
                "swal('" + titulo + "!', '" + mensaje + "!', '" + tipo + "')", true);
            }
            foreach (DataTable i in web.Tables)
                i.EndLoadData();

            Session["llaveBusinessNodo"] = llaveBusinessNodo;
        }

        //end--Mostrar de texto
        //end--Verificacion de texto

        protected void OcultarYver(int tipo)
        {
            if (tipo == 0)
            {
                lblCurp.Visible = false;
                lblNombre.Visible = false;
                lblDomicilio.Visible = false;
                lblEstado.Visible = false;
                lblMunicipio.Visible = false;
                lblSeccion.Visible = false;
                lblVigencia.Visible = false;
                txtCurp.Visible = false;
                txtNombre.Visible = false;
                txtDomicilio.Visible = false;
                txtEstado.Visible = false;
                txtMunicipio.Visible = false;
                txtSeccion.Visible = false;
                txtVigencia.Visible = false;
                imgCalendario.Visible = false;
            }
            if (tipo == 1)
            {
                lblCurp.Visible = true;
                lblNombre.Visible = true;
                lblDomicilio.Visible = true;
                lblEstado.Visible = true;
                lblMunicipio.Visible = true;
                lblSeccion.Visible = true;
                lblVigencia.Visible = true;
                txtCurp.Visible = true;
                txtNombre.Visible = true;
                txtDomicilio.Visible = true;
                txtEstado.Visible = true;
                txtMunicipio.Visible = true;
                txtSeccion.Visible = true;
                txtVigencia.Visible = true;
                imgCalendario.Visible = true;
            }
            if (tipo == 2)
            {
                lblbuscar.Visible = false;
                lblBCurp.Visible = false;
                txtSearch.Visible = false;
            }
            if (tipo == 3)
            {
                lblbuscar.Visible = true;
                lblBCurp.Visible = true;
                txtSearch.Visible = true;
            }
            if (tipo==4)
            {
                lbldiposte.Visible = false;
                lbleliminar.Visible = false;
                txtDelete.Visible = false;
            }
            if (tipo==5)
            {
                lbldiposte.Visible = true;
                lbleliminar.Visible = true;
                txtDelete.Visible = true;
            }

        }
    }
}