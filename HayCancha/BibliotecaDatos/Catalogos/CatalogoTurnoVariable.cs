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
    public class CatalogoTurnoVariable : CatalogoGenerico<TurnoVariable>
    {
        public static List<TurnoVariable> RecuperarPorFechaYHora(DateTime fecha, int horaDesde, int horaHasta, ISession nhSesion)
        {
            try
            {
                List<TurnoVariable> listaTurnos = CatalogoGenerico<TurnoVariable>.RecuperarLista(x => x.FechaHoraDesde.Date == fecha.Date && x.FechaHoraDesde.Hour >= horaDesde && x.FechaHoraHasta.Hour <= horaHasta, nhSesion);
                return listaTurnos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TurnoVariable RecuperarPorFechaYHoraYCancha(DateTime fecha, int horaDesde, int horaHasta, int codigoCancha, ISession nhSesion)
        {
            try
            {
                TurnoVariable turnoVariable = CatalogoGenerico<TurnoVariable>.RecuperarPor(x => x.FechaHoraDesde.Date == fecha.Date && x.FechaHoraDesde.Hour >= horaDesde && x.FechaHoraHasta.Hour <= horaHasta && x.Cancha.Codigo == codigoCancha, nhSesion);
                return turnoVariable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TurnoVariable> RecuperarPorFechaYHoraYComplejo(DateTime fecha, int horaDesde, int horaHasta, int codigoComplejo, ISession nhSesion)
        {
            try
            {
                List<TurnoVariable> listaTurnos = nhSesion.QueryOver<TurnoVariable>().Where(x => x.FechaHoraDesde.Date == fecha.Date && x.FechaHoraDesde.Hour >= horaDesde && x.FechaHoraHasta.Hour <= horaHasta).JoinQueryOver(c => c.Cancha).Where(ch => ch.Complejo.Codigo == codigoComplejo).List().ToList();
                return listaTurnos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TurnoVariable RecuperarTurnoPorCanchaYFechas(DateTime fechaHoraDesde, DateTime fechaHoraHasta, int codigoCancha, ISession nhSesion)
        {
            try
            {
                TurnoVariable turnoV = CatalogoGenerico<TurnoVariable>.RecuperarPor(x => x.Cancha.Codigo == codigoCancha && (x.EstadoTurno.Codigo == Constantes.EstadosTurno.PENDIENTE || x.EstadoTurno.Codigo == Constantes.EstadosTurno.RESERVADO) && x.FechaHoraDesde >= fechaHoraDesde && x.FechaHoraHasta <= fechaHoraHasta, nhSesion);
                return turnoV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<TurnoVariable> RecuperarTurnoPorCanchaYFecha(DateTime fecha, int codigoCancha, ISession nhSesion)
        {
            try
            {
                List<TurnoVariable> turnoV = CatalogoGenerico<TurnoVariable>.RecuperarLista(x => x.Cancha.Codigo == codigoCancha, nhSesion);//&& x.FechaHoraDesde.ToString("dd/MM/yyyy") == fecha.ToString("dd/MM/yyyy"), nhSesion);
                return turnoV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TurnoVariable RecuperarTurnoPorCanchaYHora(int HoraDesde, int codigoCancha, ISession nhSesion)
        {
            try
            {
                TurnoVariable turnoV = CatalogoGenerico<TurnoVariable>.RecuperarPor(x => x.Cancha.Codigo == codigoCancha && x.FechaHoraDesde.Hour == HoraDesde, nhSesion);
                return turnoV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
