using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using NHibernate;

namespace BibliotecaDatos.Catalogos
{
    public class CatalogoTurnoVariable : CatalogoGenerico<TurnoVariable>
    {
        public static List<TurnoVariable> RecuperarPorFechaYHora(DateTime fecha, int horaDesde, int horaHasta, ISession nhSesion)
        {
            List<TurnoVariable> listaTurnos = CatalogoGenerico<TurnoVariable>.RecuperarLista(x => x.FechaHoraDesde.Date == fecha.Date && x.FechaHoraDesde.Hour >= horaDesde && x.FechaHoraHasta.Hour <= horaHasta, nhSesion);
            return listaTurnos;
        }
    }
}
