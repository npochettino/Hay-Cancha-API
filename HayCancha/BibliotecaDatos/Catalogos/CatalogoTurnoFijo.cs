using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
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
    }
}
