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
    public partial class complejo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadComplejo();
        }

        private void LoadComplejo()
        {
            DataTable dtComplejoActual = ControladorUsuarios.RecuperarUsuarioWeb(Session["mailUsuarioActual"].ToString(), Session["contraseñaUsuarioActual"].ToString());
                
            Session.Add("codigoComplejo", dtComplejoActual.Rows[0]["codigoComplejo"].ToString());
            txtNombreComplejo.Text = dtComplejoActual.Rows[0]["descripcionComplejo"].ToString();
            txtDireccion.Text = dtComplejoActual.Rows[0]["direccionComplejo"].ToString();
            txtTelefono.Text = dtComplejoActual.Rows[0]["telefonoComplejo"].ToString();
            ddlHoraApertura.Text = dtComplejoActual.Rows[0]["horaApertura"].ToString();
            ddlHoraCierre.Text = dtComplejoActual.Rows[0]["horaCierre"].ToString();
            txtMailComplejo.Text = dtComplejoActual.Rows[0]["mailComplejo"].ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ControladorGeneral.InsertarActualizarComplejo(Convert.ToInt32(Session["codigoComplejo"].ToString()), txtNombreComplejo.Text, txtDireccion.Text,
                Convert.ToInt32(ddlHoraApertura.SelectedValue), Convert.ToInt32(ddlHoraCierre.SelectedValue), txtMailComplejo.Text, txtTelefono.Text, Convert.ToDouble(34.5555), Convert.ToDouble(34.5555));
        }
    }
}