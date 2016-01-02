using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaLogica.Controladores;
using System.Net.Mail;

namespace HayCancha
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (ControladorUsuarios.InsertarActualizarUsuarioWeb(0, string.Empty, string.Empty, txtEmail.Value, txtContraseña.Value) == "ok")
            {
                Session.Add("contraseñaUsuarioActual", txtContraseña.Value);
                Session.Add("mailUsuarioActual", txtEmail.Value);
                //Response.Redirect("bienvenido.aspx");
                EnviarEmailNewRegistro(txtEmail.Value);
                Response.Redirect("login.aspx");
            }
            else
            {
                lblError.Style.Add("display", "block");
            }
        }

        private void EnviarEmailNewRegistro(string mail)
        {
            string HTML = "";

            HTML = File.ReadAllText(Server.MapPath("/email/emailRegistroWeb.html"));
            
            //Envio el mail
            MailMessage mailMessage = new MailMessage();

            mailMessage.To.Add(mail);

            mailMessage.From = new MailAddress("haycancha@sempait.com.ar", "Bienvenido a HayCancha Admin");
            //email's subject
            mailMessage.Subject = "Hay Cancha";
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}