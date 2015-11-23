using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using BibliotecaDatos.ClasesComplementarias;
using NHibernate;

namespace BibliotecaDatos.Catalogos
{
    public class CatalogoTurnoFijo : CatalogoGenerico<TurnoFijo>
    {
        public static List<TurnoFijo> RecuperarPorFechaYHora(DateTime fecha, int horaDesde, int horaHasta, ISession nhSesion)
        {
            try
            {
                List<TurnoFijo> listaTurnos = CatalogoGenerico<TurnoFijo>.RecuperarLista(x => x.FechaDesde <= fecha && x.FechaHasta == null && x.HoraDesde >= horaDesde && x.HoraHasta <= horaHasta && x.CodigoDiaSemana == Convert.ToInt32(fecha.DayOfWeek), nhSesion);
                return listaTurnos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TurnoFijo> RecuperarPorFechaYHoraYComplejo(DateTime fecha, int horaDesde, int horaHasta, int codigoComplejo, ISession nhSesion)
        {
            try
            {
                List<TurnoFijo> listaTurnos = nhSesion.QueryOver<TurnoFijo>().Where(x => x.FechaDesde <= fecha && x.FechaHasta == null && x.HoraDesde >= horaDesde && x.HoraHasta <= horaHasta && x.CodigoDiaSemana == Convert.ToInt32(fecha.DayOfWeek)).JoinQueryOver(c => c.Cancha).Where(ch => ch.Complejo.Codigo == codigoComplejo).List().ToList();
                return listaTurnos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TurnoFijo RecuperarTurnoPorCanchaYFechas(DateTime fechaHoraDesde, DateTime fechaHoraHasta, int codigoCancha, ISession nhSesion)
        {
            try
            {
                TurnoFijo turnoF = CatalogoGenerico<TurnoFijo>.RecuperarPor(x => x.Cancha.Codigo == codigoCancha && x.FechaHasta == null && x.CodigoDiaSemana == Convert.ToInt32(fechaHoraDesde.DayOfWeek) && x.HoraDesde <= fechaHoraDesde.Hour && x.HoraHasta >= fechaHoraHasta.Hour, nhSesion);
                return turnoF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TurnoFijo> RecuperarTurnoPorCanchaYFecha(DateTime fecha, int codigoCancha, ISession nhSesion)
        {
            try
            {
                List<TurnoFijo> turnoV = CatalogoGenerico<TurnoFijo>.RecuperarLista(x => x.Cancha.Codigo == codigoCancha && x.CodigoDiaSemana == Convert.ToInt32(fecha.DayOfWeek), nhSesion);
                return turnoV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TurnoFijo RecuperarTurnoPorCanchaYHora(int HoraDesde, int codigoCancha, ISession nhSesion)
        {
            try
            {
                TurnoFijo turnoF = CatalogoGenerico<TurnoFijo>.RecuperarPor(x => x.Cancha.Codigo == codigoCancha && x.FechaHasta == null && x.HoraDesde == HoraDesde, nhSesion);
                return turnoF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
