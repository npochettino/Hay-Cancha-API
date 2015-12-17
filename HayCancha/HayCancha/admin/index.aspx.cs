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
            //if (Session["codigoComplejo"] != null)
            //    LoadGrillaTurnosNew();
            //else
            //    Response.Redirect("../login.aspx");
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

        //private void LoadGrillaTurnos()
        //{
        //    DataTable dtComplejo = ControladorGeneral.RecuperarComplejo(Convert.ToInt32(Session["codigoComplejo"]));
        //    DataTable dtCanchas = ControladorGeneral.RecuperarCanchasPorComplejo(Convert.ToInt32(Session["codigoComplejo"]));
        //    Session.Add("dtCanchasActual", dtCanchas);

        //    int HoraApertura = Convert.ToInt32(dtComplejo.Rows[0]["horaApertura"]);
        //    int HoraCierre = Convert.ToInt32(dtComplejo.Rows[0]["horaCierre"]);
        //    DataTable dtTurnos = new DataTable();

        //    if (dtCanchas.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtCanchas.Rows.Count; i++)
        //        {
        //            DataTable dtTurnosPorCancha = new DataTable(); //ControladorTurnos.RecuperarTurnosPorFechaPorCancha(DateTime.Now, Convert.ToInt32(dtCanchas.Rows[i]["codigoCancha"]));
        //            if (i == 0)
        //            {
        //                dtTurnos.Columns.Add("Id");
        //                dtTurnos.Columns.Add("Hora");
        //                for (int h = HoraApertura; h <= HoraCierre; h++)
        //                    dtTurnos.Rows.Add(h, h + ":00");

        //                dtTurnos.Columns.Add(dtCanchas.Rows[i]["descripcion"].ToString());
        //                foreach (DataRow dr in dtTurnos.Rows)
        //                {
        //                    int hora = Convert.ToInt32(dr.ItemArray[0]);
        //                    string contains = isContains(hora, dtTurnosPorCancha);
        //                    dr[dtCanchas.Rows[i]["descripcion"].ToString()] = contains;
        //                }
        //            }
        //            else
        //            {
        //                dtTurnos.Columns.Add(dtCanchas.Rows[i]["descripcion"].ToString());
        //                foreach (DataRow dr in dtTurnos.Rows)
        //                {
        //                    int hora = Convert.ToInt32(dr.ItemArray[0]);
        //                    string contains = isContains(hora, dtTurnosPorCancha);
        //                    dr[dtCanchas.Rows[i]["descripcion"].ToString()] = contains;
        //                }
        //            }
        //        }
        //        gvTurnos.DataSource = dtTurnos;
        //        gvTurnos.DataBind();
        //        gvTurnos.Columns["Id"].Visible = false;
        //        gvTurnos.Columns["Hora"].Width = 20;
        //        gvTurnos.DataBind();
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('El complejo aun no tiene canchas. Crea una cancha para poder comenzar a gestionar tus reservas!');</script>");
        //    }

        //}

        //private string isContains(int h, DataTable dtTurnosPorCancha)
        //{
        //    for (int i = 0; i < dtTurnosPorCancha.Rows.Count; i++)
        //    {
        //        if (dtTurnosPorCancha.Rows[i]["horaDesde"].ToString().Contains(h.ToString()))
        //            return dtTurnosPorCancha.Rows[i]["estado"].ToString();
        //    }
        //    return "Libre";
        //}


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

            if (estado == "Disponible")
            {
                btnAceptar.Visible = false;
                btnRechazar.Visible = false;
                btnGuardarTurno.Visible = true;
                //Muestro Pop Up en blanco....
            }
            else
            {
                btnAceptar.Visible = true;
                btnRechazar.Visible = true;
                btnGuardarTurno.Visible = false;

                int codigoTurno = int.Parse(gvTurnos.GetRowValues(gvTurnos.FocusedRowIndex, "codigoTurno" + nombreCancha).ToString());
                Session.Add("codigoTurno", codigoTurno);
                
                DataTable dtTurnoActual = ControladorTurnos.RecuperarTurnoPorCodigo(codigoTurno);
                
                Session.Add("descripcionComplejo",dtTurnoActual.Rows[0]["descripcionComplejo"].ToString());
                Session.Add("telefonoUsuarioApp", dtTurnoActual.Rows[0]["telefonoUsuarioApp"].ToString());

                lblNombreDelUsuario.Text = dtTurnoActual.Rows[0]["nombreUsuarioApp"].ToString();
                txtNombreUsuario.Text = dtTurnoActual.Rows[0]["nombreUsuarioApp"].ToString();
                txtApellidoUsuario.Text = dtTurnoActual.Rows[0]["apellidoUsuarioApp"].ToString();
                txtDireccionUsuario.Text = dtTurnoActual.Rows[0]["direccionUsuarioApp"].ToString();
                txtTelefono.Text = dtTurnoActual.Rows[0]["telefonoUsuarioApp"].ToString();
                ddlHoraDesde.SelectedValue = dtTurnoActual.Rows[0]["horaDesde"].ToString();
                ddlHoraHasta.SelectedValue = dtTurnoActual.Rows[0]["horaHasta"].ToString();
            }
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
            string rta = "";
            if (ControladorTurnos.CambiarEstadoDelTurno(Convert.ToInt32(Session["codigoTurno"]), estado))
            {
                PushNotification.SendPersonalPush("reservation", Session["descripcionComplejo"].ToString() + " ha respondido!", Session["telefonoUsuarioApp"].ToString());
                rta = "Se cambio el estado del turno";
            }
            else
                rta = "ERROR";

            pcTurno.ShowOnPageLoad = false;
            LoadGrillaTurnosNew();
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            cambiarEstadoDelTurno(Constantes.EstadosTurno.CANCELADO);
        }

        
    }
}