using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class HistorialTurnoFijo
    {
        public virtual int Codigo { get; set; }
        public virtual DateTime FechaHoraDesde { get; set; }
        public virtual DateTime FechaHoraHasta { get; set; }
        public virtual double Seña { get; set; }
        public virtual string Observaciones { get; set; }

        public virtual EstadoTurno EstadoTurno { get; set; }
    }
}
