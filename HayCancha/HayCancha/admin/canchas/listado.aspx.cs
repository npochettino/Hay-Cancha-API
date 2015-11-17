using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaDatos.Clases;
using BibliotecaLogica.Controladores;

namespace HayCancha.admin.canchas
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codigoComplejo"] != null)
                {
                    int idComplejo = Convert.ToInt32(Session["codigoComplejo"]);
                    LoadCanchas(idComplejo);
                } 
        }

        private void LoadCanchas(int idComplejo)
        {            
            gvCanchas.DataSource = ControladorGeneral.RecuperarCanchasPorComplejo(idComplejo);
            gvCanchas.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("cancha.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            CargarDatosEnVariableSession();
            Response.Redirect("cancha.aspx");
        }

        private void CargarDatosEnVariableSession()
        {
            Cancha canchaActual = new Cancha();

            canchaActual.Codigo = int.Parse(gvCanchas.GetRowValues(gvCanchas.FocusedRowIndex, "codigoCancha").ToString());
            canchaActual.Descripcion = gvCanchas.GetRowValues(gvCanchas.FocusedRowIndex, "descripcion").ToString();
            canchaActual.PrecioMañana = Convert.ToDouble(gvCanchas.GetRowValues(gvCanchas.FocusedRowIndex, "precioMañana"));
            canchaActual.PrecioTarde = Convert.ToDouble(gvCanchas.GetRowValues(gvCanchas.FocusedRowIndex, "precioTarde"));
            canchaActual.PrecioNoche = Convert.ToDouble(gvCanchas.GetRowValues(gvCanchas.FocusedRowIndex, "precioMañana"));
            canchaActual.TipoCancha.Codigo = int.Parse(gvCanchas.GetRowValues(gvCanchas.FocusedRowIndex, "codigoTipoCancha").ToString());
            canchaActual.TipoCancha.Descripcion = gvCanchas.GetRowValues(gvCanchas.FocusedRowIndex, "descripcionTipoCancha").ToString();
           
            Session.Add("canchaActual", canchaActual);
        }
    }
}