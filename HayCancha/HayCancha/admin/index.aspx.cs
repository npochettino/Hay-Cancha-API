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

namespace HayCancha.admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrillaTurnos();
        }

        private void LoadGrillaTurnos()
        {
            DataTable dtComplejo = ControladorGeneral.RecuperarComplejo(Convert.ToInt32(Session["codigoComplejo"]));
            DataTable dtCanchas = ControladorGeneral.RecuperarCanchasPorComplejo(Convert.ToInt32(Session["codigoComplejo"]));

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

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            foreach (GridViewColumn column in gvTurnos.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                column.CellStyle.Font.Bold = dataColumn.SortOrder != ColumnSortOrder.None;
            }
        }

    }
}