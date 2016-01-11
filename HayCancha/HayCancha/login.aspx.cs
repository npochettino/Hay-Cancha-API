using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaLogica.Controladores;
using System.Net.Mail;

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
                Session.Add("codigoUsuario", dtUsuarioActual.Rows[0]["codigoUsuario"]);
                Session.Add("codigoComplejo", dtUsuarioActual.Rows[0]["codigoComplejo"]);
                Session.Add("logoComplejo", dtUsuarioActual.Rows[0]["logoComplejo"]);

                Response.Redirect("admin\\index.aspx");
            }
            else
            {
                lblErrorLogin.Style.Add("display", "block");
            }
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            DataTable dtUsuarioActual = ControladorUsuarios.RecuperarContraseñaWeb(txtMailOlvidaPass.Value.Trim());
            if (dtUsuarioActual != null)
            {
                if ("ok" == EnviarEmailOlvidaPass(dtUsuarioActual.Rows[0]["mail"].ToString(), dtUsuarioActual.Rows[0]["contraseña"].ToString()))
                {
                    lblOkForgotPass.Style.Add("display", "block");
                    lblErrorForgotPass.Style.Add("display", "none");
                    divLogin.Disabled = true;
                    divForgotPass.Disabled = false;
                }
            }
            else
            {
                lblErrorForgotPass.Style.Add("display", "block");
                lblOkForgotPass.Style.Add("display", "none");
                divLogin.Disabled = true;
                divForgotPass.Disabled = false;
            }
        }

        private string EnviarEmailOlvidaPass(string mail, string contraseña)
        {
            string HTML = "";

            HTML = File.ReadAllText(Server.MapPath("/haycancha/email/emailPasswordWeb.html"));
            HTML = HTML.Replace("varContraseña", contraseña);
            HTML = HTML.Replace("varMail", mail);

            //Envio el mail
            MailMessage mailMessage = new MailMessage();

            mailMessage.To.Add(mail);

            mailMessage.From = new MailAddress("haycancha@sempait.com.ar", "HayCancha Admin");
            //email's subject
            mailMessage.Subject = "Hay Cancha - Recuperar Contraseña";
            //email's body, this is going to be html. note that we attach the image as using cid
            mailMessage.Body = HTML;
            //set email's body to html
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
            //client.EnableSsl = true; 
            SmtpClient smtp = new SmtpClient();
            smtp.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP_SERVER"].ToString();

            try
            {
                smtp.Send(mailMessage);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
                return "fallo";
            }
        }
    }
}