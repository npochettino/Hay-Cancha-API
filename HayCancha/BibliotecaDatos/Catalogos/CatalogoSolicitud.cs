using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using NHibernate;

namespace BibliotecaDatos.Catalogos
{
    public class CatalogoSolicitud
    {
        public static List<Solicitud> RecuperarPorTurnos(List<int> listaTurnos, ISession nhSesion)
        {
            try
            {
                List<Solicitud> listaSolicitudes = nhSesion.QueryOver<Solicitud>().Where(x => x.TurnoVariable != null).JoinQueryOver(x => x.TurnoVariable).WhereRestrictionOn(x => x.Codigo).IsIn(listaTurnos).List().ToList();
                return listaSolicitudes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Solicitud> RecuperarPorTurnosYEstado(List<int> listaTurnos, int codigoEstadoSolicitud, ISession nhSesion)
        {
            try
            {
                List<Solicitud> listaSolicitudes = nhSesion.QueryOver<Solicitud>().Where(x => x.TurnoVariable != null && x.EstadoSolicitud.Codigo == codigoEstadoSolicitud).JoinQueryOver(x => x.TurnoVariable).WhereRestrictionOn(x => x.Codigo).IsIn(listaTurnos).List().ToList();
                return listaSolicitudes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
