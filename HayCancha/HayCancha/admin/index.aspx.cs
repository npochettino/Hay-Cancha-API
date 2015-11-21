using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaLogica.Controladores;

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
            //for (int i = 0; i < dtCanchas.Rows.Count; i++)
            //{
            //    dtTurnos.Columns.Add(dtCanchas.Rows[i]["descripcion"].ToString());
            //}
            
            if (dtCanchas.Rows.Count > 0)
            {
                for (int i = 0; i < dtCanchas.Rows.Count; i++)
                {
                    DataTable dtTurnosPorCancha = ControladorTurnos.RecuperarTurnosPorFechaPorCancha(DateTime.Now, Convert.ToInt32(dtCanchas.Rows[i]["codigoCancha"]));
                    if (i == 0)
                    {
                        dtTurnos.Columns.Add("Hora");
                        foreach (DataRow dr in dtTurnos.Rows)
                        {
                            for (int h = HoraApertura; h <= HoraCierre; h ++ )
                                dr["Hora"] = h;   // or set it to some other value
                        }

                        dtTurnos.Columns.Add(dtCanchas.Rows[i]["descripcion"].ToString());
                        int index = -1;
                        foreach (DataRow dr in dtTurnos.Rows)
                        {
                            for (int h = HoraApertura; h <= HoraCierre; h++)
                                if (dtTurnosPorCancha.Rows[h]["horaDesde"].ToString().Contains(h.ToString()))
                                    dr[dtCanchas.Rows[i]["descripcion"].ToString()] = dtTurnosPorCancha.Rows[h]["estado"].ToString();
                                else
                                    dr[dtCanchas.Rows[i]["descripcion"].ToString()] = "Libre";
                            // or set it to some other value
                        }
                        //for (int c = Convert.ToInt32(dtComplejo.Rows[0]["horaApertura"]); c <= Convert.ToInt32(dtComplejo.Rows[0]["horaCierre"]); c++)
                        //    dtTurnos.Rows.Add("lalala");
                    }
                    else
                    {
                        dtTurnos.Columns.Add(dtCanchas.Rows[i]["descripcion"].ToString());
                        foreach (DataRow dr in dtTurnos.Rows)
                        {
                            //need to set value to MyRow column
                            dr[dtCanchas.Rows[i]["descripcion"].ToString()] = "kakakak";   // or set it to some other value
                        }
                    }
                }
                gvTurnos.DataSource = dtTurnos;
                gvTurnos.DataBind();
            }
            else
            {
                Response.Write("<script>alert('El complejo aun no tiene canchas. Crea una cancha para poder comenzar a gestionar tus reservas!');</script>");
            }
            
        }
    }
}