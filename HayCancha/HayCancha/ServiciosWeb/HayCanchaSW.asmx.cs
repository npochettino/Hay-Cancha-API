using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        public string InsertarActualizarUsuarioApp(int codigoUsuario, string nombre, string apellido, string mail, string contraseña, string telefono, int codigoPosicion)
        {
            try
            {
                ControladorUsuarios.InsertarActualizarUsuarioApp(codigoUsuario, nombre, apellido, mail, contraseña, telefono, codigoPosicion);
                return "ok";
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
        public string RecuperarTurnosPorRangoHorario(string fechaStr, int horaDesde, int horaHasta, int codigoUsuarioApp)
        {
            try
            {
                DateTime fecha = Convert.ToDateTime(fechaStr);
                DataTable tablaTurnos = ControladorTurnos.RecuperarTurnosPorRangoHorario(fecha, horaDesde, horaDesde, codigoUsuarioApp);
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
        public string InsertarActualizarTurnoVariable(int codigoTurnoVariable, int codigoCancha, string fecha, int horaDesde, int HoraHasta, int codigoUsuarioApp, string observaciones)
        {
            try
            {
                DateTime fechaHoraDesde = Convert.ToDateTime(fecha + " " + horaDesde.ToString("00") + ":00:00");
                DateTime fechaHoraHasta = Convert.ToDateTime(fecha + " " + HoraHasta.ToString("00") + ":00:00");

                ControladorTurnos.InsertarActualizarTurnoVariable(codigoTurnoVariable, codigoCancha, fechaHoraDesde, fechaHoraHasta, codigoUsuarioApp, observaciones, string.Empty, 0.0);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
