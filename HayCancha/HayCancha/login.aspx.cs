using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaLogica.Controladores;

namespace HayCancha
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Clear();
            //Session.Abandon();
        }     
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dtUsuarioActual = ControladorUsuarios.RecuperarUsuarioWeb(txtEmail.Value.Trim(), txtContraseña.Value.Trim());
            if (dtUsuarioActual.Rows.Count != 0)
            {
                Session.Add("contraseñaUsuarioActual", dtUsuarioActual.Rows[0]["contraseña"].ToString());
                Session.Add("mailUsuarioActual", dtUsuarioActual.Rows[0]["mail"].ToString());
                Response.Redirect("admin\\index.aspx");
            }
            else
            {
                lblErrorLogin.Style.Add("display", "block");
            }
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            //DataTable dtUsuarioActual = ControladorUsuarios.RecuperarUsuarioWeb(txtEmail.Value.Trim(), txtContraseña.Value.Trim());
            //if (dtUsuarioActual != null)
            //{
            //    Session.Add("usuarioLogueado", dtUsuarioActual.Rows[0][1].ToString());
            //    Response.Redirect("login.aspx");
            //}
            //else
            //{
                lblErrorForgotPass.Style.Add("display", "block");
            //}
        }
    }
}