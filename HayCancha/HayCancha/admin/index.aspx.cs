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

namespace HayCancha.admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codigoComplejo"] != null)
                LoadGrillaTurnosNew();
            else
                Response.Redirect("../login.aspx");
        }

        private void LoadGrillaTurnosNew()
        {
            gvTurnosComplejo.DataSource = ControladorTurnos.RecuperarTurnosPorComplejoPorDia(DateTime.Now,Convert.ToInt32(Session["codigoComplejo"]));
            gvTurnosComplejo.DataBind();
        }

        private void LoadGrillaTurnos()
        {
            DataTable dtComplejo = ControladorGeneral.RecuperarComplejo(Convert.ToInt32(Session["codigoComplejo"]));
            DataTable dtCanchas = ControladorGeneral.RecuperarCanchasPorComplejo(Convert.ToInt32(Session["codigoComplejo"]));
            Session.Add("dtCanchasActual", dtCanchas);

            int HoraApertura = Convert.ToInt32(dtComplejo.Rows[0]["horaApertura"]);
            int HoraCierre = Convert.ToInt32(dtComplejo.Rows[0]["horaCierre"]);
            DataTable dtTurnos = new DataTable();

            if (dtCanchas.Rows.Count > 0)
            {
                for (int i = 0; i < dtCanchas.Rows.Count; i++)
                {
                    DataTable dtTurnosPorCancha = new DataTable(); //ControladorTurnos.RecuperarTurnosPorFechaPorCancha(DateTime.Now, Convert.ToInt32(dtCanchas.Rows[i]["codigoCancha"]));
                    if (i == 0)
                    {
                        dtTurnos.Columns.Add("Id");
                        dtTurnos.Columns.Add("Hora");
                        for (int h = HoraApertura; h <= HoraCierre; h++)
                            dtTurnos.Rows.Add(h, h + ":00");

                        dtTurnos.Columns.Add(dtCanchas.Rows[i]["descripcion"].ToString());
                        foreach (DataRow dr in dtTurnos.Rows)
                        {
                            int hora = Convert.ToInt32(dr.ItemArray[0]);
                            string contains = isContains(hora, dtTurnosPorCancha);
                            dr[dtCanchas.Rows[i]["descripcion"].ToString()] = contains;
                        }
                    }
                    else
                    {
                        dtTurnos.Columns.Add(dtCanchas.Rows[i]["descripcion"].ToString());
                        foreach (DataRow dr in dtTurnos.Rows)
                        {
                            int hora = Convert.ToInt32(dr.ItemArray[0]);
                            string contains = isContains(hora, dtTurnosPorCancha);
                            dr[dtCanchas.Rows[i]["descripcion"].ToString()] = contains;
                        }
                    }
                }
                gvTurnos.DataSource = dtTurnos;
                gvTurnos.DataBind();
                gvTurnos.Columns["Id"].Visible = false;
                gvTurnos.Columns["Hora"].Width = 20;
                gvTurnos.DataBind();
            }
            else
            {
                Response.Write("<script>alert('El complejo aun no tiene canchas. Crea una cancha para poder comenzar a gestionar tus reservas!');</script>");
            }

        }

        private string isContains(int h, DataTable dtTurnosPorCancha)
        {
            for (int i = 0; i < dtTurnosPorCancha.Rows.Count; i++)
            {
                if (dtTurnosPorCancha.Rows[i]["horaDesde"].ToString().Contains(h.ToString()))
                    return dtTurnosPorCancha.Rows[i]["estado"].ToString();
            }
            return "Libre";
        }

        protected void gvTurnos_FillContextMenuItems(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewContextMenuEventArgs e)
        {
            e.Items.Add("PDF", "ExportToPDF");
            e.Items.Add("XLS", "ExportToXLS");
        }

        protected void gvTurnos_ContextMenuItemClick(object sender, ASPxGridViewContextMenuItemClickEventArgs e)
        {

        }

        protected void ASPxPopupMenu1_ItemClick(object sender, MenuItemEventArgs e)
        {
            if (e.Item == null)
                return;
            gvTurnos.ClearSort();
            GridViewDataColumn clickedColumn = (GridViewDataColumn)gvTurnos.Columns[e.Item.Name];
        }


        //protected void gvTurnos_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        //{
        //    e.Properties["cpDataColumnMap"] = gvTurnos.DataColumns.ToDictionary(c => gvTurnos.DataColumns.IndexOf(c), c => c.FieldName);
        //}

        //protected void gvTurnos_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        //{
        //    e.Cell.Attributes["data-CI"] = string.Format("{0}_{1}", e.VisibleIndex, gvTurnos.DataColumns.IndexOf(e.DataColumn)); // cell info
        //}
        protected void gridView_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            e.Cell.Attributes.Add("onclick", String.Format("onCellClick({0}, '{1}', '{2}')", e.KeyValue, e.DataColumn.FieldName, e.CellValue.ToString()));
        }
        protected void gridView_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parameter = e.Parameters.Split('|');
            int visibleIndex = int.Parse(parameter[0]);
            string fieldName = parameter[1];
            string status = parameter[2];

            Session.Add("horaSeleccionada", visibleIndex);
            Session.Add("canchaSeleccionada", fieldName);
            Session.Add("estadoSeleccionada", status);

            if (status == "Libre")
            {
                LoadPopUp();
            }
            else
            {
                DataTable dtCanchasActual = (DataTable)Session["dtCanchasActual"];
                int idCanchaSeleccionada = 1;
                for (int i = 0; i < dtCanchasActual.Rows.Count; i++)
                {
                    if (dtCanchasActual.Rows[i]["descripcion"].ToString().Contains(fieldName.ToString()))
                        idCanchaSeleccionada = Convert.ToInt32(dtCanchasActual.Rows[i]["codigoCancha"]);
                }
                
                //DataTable dtTurnoSeleccionado = ControladorTurnos.RecuperarTurnoPorCanchaYHora(idCanchaSeleccionada,visibleIndex);
                //LoadPopUp(dtTurnoSeleccionado);
            }
        }
        
        private void LoadPopUp()
        {
            Response.Write("<script>alert('Muestro PopUp para cargar nuevo turno .....!');</script>");
        }

        private void LoadPopUp(DataTable dtTurnoSeleccionado)
        {
            pcTurno.ShowOnPageLoad = true;
        }
        
        protected void pcTurno_PreRender(object sender, EventArgs e)
        {
            if (Session["horaSeleccionada"] != null)
            {
                //lblNombre.Text = "pepepe";
                //lblApellido.Text = "apelll";
                //lblDireccion.InnerText = "innertext";
                //lblDireccion.InnerHtml = "innerhtml";

            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvTurnosComplejo, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string estado = gvTurnosComplejo.SelectedRow.Cells[1].Text;
            if (estado == "Disponible")
            {
                pcTurno.ShowOnPageLoad = true;
            }
            else
            {
                string horaDesdeHasta = gvTurnosComplejo.SelectedRow.Cells[0].Text;
                string nombreCancha = gvTurnosComplejo.HeaderRow.Cells[1].Text;

                DateTime dt = DateTime.Now;
                DataTable dtTurnoActual = ControladorTurnos.RecuperarTurnoPorNombreCanchayHora(Convert.ToInt32(Session["codigoComplejo"]),nombreCancha, dt);
            }           
            
            
            
        }
    }
}