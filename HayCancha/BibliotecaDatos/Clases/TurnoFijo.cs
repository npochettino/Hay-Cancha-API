using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class TurnoFijo
    {
        public TurnoFijo()
        {
            HistorialTurnoFijo = new List<HistorialTurnoFijo>();
        }

        public virtual int Codigo { get; set; }
        public virtual string Responsable { get; set; }
        public virtual int CodigoDiaSemana { get; set; }
        public virtual int HoraDesde { set; get; }
        public virtual int HoraHasta { set; get; }
        public virtual DateTime FechaDesde { set; get; }
        public virtual DateTime? FechaHasta { set; get; }
        public virtual string Observaciones { get; set; }
        public virtual double Seña { get; set; }
        public virtual int CantidadJugadoresFaltantes { get; set; }

        public virtual Cancha Cancha { get; set; }
        public virtual UsuarioWeb UsuarioWeb { get; set; }
        public virtual IList<HistorialTurnoFijo> HistorialTurnoFijo { get; set; }
    }
}
