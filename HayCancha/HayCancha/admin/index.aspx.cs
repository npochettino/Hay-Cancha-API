using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaLogica.Controladores;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxMenu;
using DevExpress.Data;
using System.Web.Services;
using BibliotecaDatos.ClasesComplementarias;

namespace HayCancha.admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codigoComplejo"] == null)
                Response.Redirect("../login.aspx");

            if (!IsPostBack)
                LoadGrillaTurnosNew();
        }

        private void LoadGrillaTurnosNew()
        {
            if (txtFechaGrillaTurnos.Date < DateTime.Now.AddYears(-50))
                txtFechaGrillaTurnos.Date = DateTime.Now;

            gvTurnos.DataSource = ControladorTurnos.RecuperarTurnosPorComplejoPorDia(txtFechaGrillaTurnos.Date, Convert.ToInt32(Session["codigoComplejo"]));
            gvTurnos.DataBind();

            DataTable dtCanchas = ControladorGeneral.RecuperarCanchasPorComplejo(Convert.ToInt32(Session["codigoComplejo"]));

            for (int i = 0; i < dtCanchas.Rows.Count; i ++)
                gvTurnos.Columns["codigo Turno " + dtCanchas.Rows[i]["descripcion"].ToString()].Visible = false;
            
            gvTurnos.DataBind();
            
        }

        protected void gridView_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.Cell != null)
            {
                e.Cell.Attributes.Add("onclick", "ShowEditPopup('" + e.Cell.ID + "','" + e.DataColumn.FieldName + "','" + e.KeyValue + "','" + e.CellValue + "');");
            }
        }

        protected void ASPxCallbackPanel1_Callback1(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            string[] parameter = e.Parameter.Split(',');
            string nombreCancha = parameter[0];
            string horaDesdeHasta = parameter[1];
            string estado = parameter[2];
            
            Session.Add("horaSeleccionada", horaDesdeHasta);
            Session.Add("canchaSeleccionada", nombreCancha);
            Session.Add("estadoSeleccionada", estado);

            if (estado.Contains("Reservado -"))
            {
                btnAceptar.Visible = false;
                btnRechazar.Visible = false;
                btnGuardarTurno.Visible = false;
                btnEliminarReserva.Visible = true;

                cargarDatosTurno(nombreCancha);
            }

            if (estado == "Disponible")
            {
                btnAceptar.Visible = false;
                btnRechazar.Visible = false;
                btnGuardarTurno.Visible = true;
                btnEliminarReserva.Visible = false;
                //Muestro Pop Up en blanco....
                imgProfileUserApp.ImageUrl = "~\\ImagenesComplejos\\logo_complejo_default.png";
                //divValoracionTurno.Style
            }
            if (estado.Contains("Pendiente de confirmación -"))
            {
                btnAceptar.Visible = true;
                btnRechazar.Visible = true;
                btnGuardarTurno.Visible = false;
                btnEliminarReserva.Visible = false;

                cargarDatosTurno(nombreCancha);
            }
                
            
        }

        private void cargarDatosTurno(string nombreCancha)
        {
            int codigoTurno = int.Parse(gvTurnos.GetRowValues(gvTurnos.FocusedRowIndex, "codigoTurno" + nombreCancha).ToString());
            Session.Add("codigoTurno", codigoTurno);

            DataTable dtTurnoActual = ControladorTurnos.RecuperarTurnoPorCodigo(codigoTurno);

            Session.Add("descripcionComplejo", dtTurnoActual.Rows[0]["descripcionComplejo"].ToString());
            Session.Add("codigoTelefonoUsuarioApp", dtTurnoActual.Rows[0]["codigoTelefonoUsuarioApp"].ToString());

            lblNombreDelUsuario.Text = dtTurnoActual.Rows[0]["nombreUsuarioApp"].ToString();
            txtNombreUsuario.Text = dtTurnoActual.Rows[0]["nombreUsuarioApp"].ToString();
            txtApellidoUsuario.Text = dtTurnoActual.Rows[0]["apellidoUsuarioApp"].ToString();
            txtTelefono.Text = dtTurnoActual.Rows[0]["telefonoUsuarioApp"].ToString();
            txtFechaDelTurno.Date = Convert.ToDateTime(dtTurnoActual.Rows[0]["fecha"].ToString());
            ddlHoraDesde.SelectedValue = dtTurnoActual.Rows[0]["horaDesde"].ToString();
            ddlHoraHasta.SelectedValue = dtTurnoActual.Rows[0]["horaHasta"].ToString();

            imgProfileUserApp.ImageUrl = "~\\Imagenes\\" + dtTurnoActual.Rows[0]["imagenUsuarioApp"].ToString(); ;
        }

        protected void txtFechaGrillaTurnos_DateChanged(object sender, EventArgs e)
        {
            LoadGrillaTurnosNew();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            cambiarEstadoDelTurno(Constantes.EstadosTurno.RESERVADO);
        }

        private void cambiarEstadoDelTurno(int estado)
        {
            if (ControladorTurnos.CambiarEstadoDelTurno(Convert.ToInt32(Session["codigoTurno"]), estado))
            {
                if(estado == Constantes.EstadosTurno.RESERVADO)
                    PushNotification.SendPersonalPush("reservation", Session["descripcionComplejo"].ToString() + " ha respondido!", Session["codigoTelefonoUsuarioApp"].ToString());
                if(estado == Constantes.EstadosTurno.CANCELADO)
                    PushNotification.SendPersonalPush("cancelation", Session["descripcionComplejo"].ToString() + " ha respondido!", Session["codigoTelefonoUsuarioApp"].ToString());
            }
    
            pcTurno.ShowOnPageLoad = false;
            LoadGrillaTurnosNew();
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            cambiarEstadoDelTurno(Constantes.EstadosTurno.CANCELADO);
        }

        protected void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            cambiarEstadoDelTurno(Constantes.EstadosTurno.CANCELADO);
        }

        
    }
}