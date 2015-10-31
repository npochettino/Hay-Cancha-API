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
        public string RecuperarTurnosPorRangoHorario(DateTime fecha, int horaDesde, int horaHasta, int codigoUsuarioApp)
        {
            try
            {
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
    }
}
