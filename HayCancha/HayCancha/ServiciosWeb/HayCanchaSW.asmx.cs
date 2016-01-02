using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using BibliotecaLogica.Controladores;
using Newtonsoft.Json;

namespace HayCancha.ServiciosWeb
{
    [WebService(Namespace = "http://haycancha.sempait.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class HayCanchaSW : System.Web.Services.WebService
    {
        [WebMethod]
        public string InsertarActualizarUsuarioApp(int codigoUsuario, string nombre, string apellido, string mail, string contraseña, string telefono, int codigoPosicion, string codigoTelefono, bool isActivo)
        {
            try
            {
                ControladorUsuarios.InsertarActualizarUsuarioApp(codigoUsuario, nombre, apellido, mail, contraseña, telefono, codigoPosicion, codigoTelefono, isActivo);
                if (codigoUsuario == 0)
                {
                    EnviarEmail(nombre, apellido, mail, "Bienvenido", "");
                }
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarContraseña(string mail)
        {
            try
            {
                DataTable tablaUsuarioApp = ControladorUsuarios.RecuperarContraseñaApp(mail);

                if (tablaUsuarioApp.Rows.Count > 0)
                {
                    //ControladorGeneral.EnviarMail();                    
                    EnviarEmail(tablaUsuarioApp.Rows[0]["nombre"].ToString(), tablaUsuarioApp.Rows[0]["apellido"].ToString(), tablaUsuarioApp.Rows[0]["mail"].ToString(), "Recuperar Contraseña", tablaUsuarioApp.Rows[0]["contraseña"].ToString());
                    return "ok";
                }
                else
                {
                    return "UsuarioInexistente";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EnviarEmail(string nombre, string apellido, string email, string parametro, string contraseña)
        {
            string HTML = "";

            if (parametro == "Recuperar Contraseña")
            {
                HTML = File.ReadAllText(Server.MapPath("/email/emailPasswordApp.html"));
                HTML = HTML.Replace("varNombre", nombre);
                HTML = HTML.Replace("varApellido", apellido);
                HTML = HTML.Replace("varContraseña", contraseña);
                HTML = HTML.Replace("varMail", email);
            }
            if (parametro == "Bienvenido")
            {
                HTML = File.ReadAllText(Server.MapPath("/email/emailRegistroApp.html"));
                HTML = HTML.Replace("varNombre", nombre);
                HTML = HTML.Replace("varApellido", apellido);                
            }

            //Envio el mail
            MailMessage mail = new MailMessage();

            mail.To.Add(email);

            mail.From = new MailAddress("haycancha@sempait.com.ar", "Hay Cancha");
            //email's subject
            mail.Subject = "Hay Cancha - " + parametro;
            //email's body, this is going to be html. note that we attach the image as using cid
            mail.Body = HTML;
            //set email's body to html
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            //client.EnableSsl = true; 
            SmtpClient smtp = new SmtpClient();
            smtp.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP_SERVER"].ToString();
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        [WebMethod]
        public string RecuperarUsuarioApp(string mail, string contraseña)
        {
            try
            {
                DataTable tablaUsuario = ControladorUsuarios.RecuperarUsuarioApp(mail, contraseña);
                return JsonConvert.SerializeObject(tablaUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarUsuarioAppPorCodigo(int codigoUsuarioApp)
        {
            try
            {
                DataTable tablaUsuario = ControladorUsuarios.RecuperarUsuarioAppPorCodigo(codigoUsuarioApp);
                return JsonConvert.SerializeObject(tablaUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarTurnosPorRangoHorario(string fechaStr, int horaDesde, int horaHasta, int codigoUsuarioApp)
        {
            try
            {
                DateTime fecha = Convert.ToDateTime(fechaStr);
                DataTable tablaTurnos = ControladorTurnos.RecuperarTurnosPorRangoHorario(fecha, horaDesde, horaHasta, codigoUsuarioApp);
                return JsonConvert.SerializeObject(tablaTurnos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarTodasPosiciones()
        {
            try
            {
                DataTable tablaPosiciones = ControladorGeneral.RecuperarTodasPosiciones();
                return JsonConvert.SerializeObject(tablaPosiciones);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarComplejo(int codigoComplejo)
        {
            try
            {
                DataTable tablaComplejo = ControladorGeneral.RecuperarComplejo(codigoComplejo);
                return JsonConvert.SerializeObject(tablaComplejo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarTodosComplejos()
        {
            try
            {
                DataTable tablaComplejos = ControladorGeneral.RecuperarTodosComplejos();
                return JsonConvert.SerializeObject(tablaComplejos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string InsertarActualizarTurnoVariable(int codigoTurnoVariable, int codigoCancha, string fecha, int horaDesde, int horaHasta, int codigoUsuarioApp, string observaciones)
        {
            try
            {
                DateTime fechaHoraDesde = Convert.ToDateTime(fecha + " " + horaDesde.ToString("00") + ":00:00");
                DateTime fechaHoraHasta = Convert.ToDateTime(fecha + " " + horaHasta.ToString("00") + ":00:00");

                if (ControladorTurnos.ValidarTurnoDesocupado(fechaHoraDesde, fechaHoraHasta, codigoCancha))
                {
                    ControladorTurnos.InsertarActualizarTurnoVariable(codigoTurnoVariable, codigoCancha, fechaHoraDesde, fechaHoraHasta, codigoUsuarioApp, observaciones, string.Empty, 0.0);
                    return "ok";
                }
                else
                {
                    return "turnoOcupado";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarValoracionesComplejo(int codigoComplejo, int codigoUsuarioApp)
        {
            try
            {
                DataTable tablaValoraciones = ControladorGeneral.RecuperarValoracionesComplejo(codigoComplejo, codigoUsuarioApp);

                return JsonConvert.SerializeObject(tablaValoraciones);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string InsertarActualizarValoracionComplejo(int codigoComplejo, int puntaje, int codigoUsuarioApp, string comentario, string titulo)
        {
            try
            {
                ControladorGeneral.InsertarActualizarValoracionComplejo(puntaje, titulo, comentario, codigoComplejo, codigoUsuarioApp);
                return JsonConvert.SerializeObject("ok");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarUsuariosAppActivosPorPosicion(int codigoPosicion, int codigoUsuarioApp)
        {
            try
            {
                DataTable tablaUsuarios = ControladorUsuarios.RecuperarUsuariosAppActivosPorPosicion(codigoPosicion, codigoUsuarioApp);
                return JsonConvert.SerializeObject(tablaUsuarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarTurnosDisponiblesPorComplejoPorDia(string fechaStr, int codigoComplejo)
        {
            try
            {
                DateTime fecha = Convert.ToDateTime(fechaStr);
                DataTable tablaTurnos = ControladorTurnos.RecuperarTurnosDisponiblesPorComplejoPorDia(fecha, codigoComplejo);
                return JsonConvert.SerializeObject(tablaTurnos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string InsertarActualizarSolicitud(int codigoSolicitud, int codigoTurnoVariable, int codigoUsuarioAppInvitado, int codigoEstadoSolicitud)
        {
            try
            {
                ControladorGeneral.InsertarActualizarSolicitud(codigoSolicitud, codigoTurnoVariable, true, codigoUsuarioAppInvitado, codigoEstadoSolicitud);
                return JsonConvert.SerializeObject("ok");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarSolicitudesPorUsuario(int codigoUsuarioApp, int codigoEstadoSolicitud)
        {
            try
            {
                DataTable tablaSolicitudes = ControladorGeneral.RecuperarSolicitudesPorUsuario(codigoUsuarioApp, codigoEstadoSolicitud);
                return JsonConvert.SerializeObject(tablaSolicitudes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarTurnosVigentesPorUsuario(int codigoUsuarioApp)
        {
            try
            {
                DataTable tablaTurnos = ControladorTurnos.RecuperarTurnosVigentesPorUsuario(codigoUsuarioApp);
                return JsonConvert.SerializeObject(tablaTurnos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string InsertarActualizarImagenUsuarioApp(int codigoUsuarioApp, string base64)
        {
            try
            {
                string rta = ControladorUsuarios.InsertarActualizarImagenUsuarioApp(codigoUsuarioApp, base64);
                return JsonConvert.SerializeObject(rta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
