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
    public partial class perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadPerfilUsuario();
        }

        private void LoadPerfilUsuario()
        {
            DataTable dtPerfilUsuario = ControladorUsuarios.RecuperarUsuarioWeb(Session["mailUsuarioActual"].ToString(), Session["contraseñaUsuarioActual"].ToString());

            Session.Add("codigoUsuarioWeb",dtPerfilUsuario.Rows[0]["codigoUsuario"].ToString());
            lblNombreDelComplejo.Text = dtPerfilUsuario.Rows[0]["descripcionComplejo"].ToString();
            txtNombreUsuario.Text = dtPerfilUsuario.Rows[0]["nombre"].ToString();
            txtApellidoUsuario.Text = dtPerfilUsuario.Rows[0]["apellido"].ToString();
            txtMailUsuario.Text = dtPerfilUsuario.Rows[0]["mail"].ToString();

            txtPasswordUsuario.Text = dtPerfilUsuario.Rows[0]["contraseña"].ToString();
            txtNewPasswordUsuario.Text = dtPerfilUsuario.Rows[0]["contraseña"].ToString();
            txtRepeatNewPasswordUsuario.Text = dtPerfilUsuario.Rows[0]["contraseña"].ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ControladorUsuarios.InsertarActualizarUsuarioWeb(Convert.ToInt32(Session["codigoUsuarioWeb"].ToString()), txtNombreUsuario.Text, txtApellidoUsuario.Text, txtMailUsuario.Text, this.txtNewPasswordUsuario.Text);
            Session.Add("contraseñaUsuarioActual", txtNewPasswordUsuario.Text);
            Page.ClientScript.RegisterStartupScript(this.GetType(),
                "scriptValidacion", "<script>alert('Se actualizó correctamente tu perfil de usuario');window.location.assign('perfil.aspx');</script>");
        }
    }
}