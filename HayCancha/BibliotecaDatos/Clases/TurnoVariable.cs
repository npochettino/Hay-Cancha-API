using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class TurnoVariable
    {
        public virtual int Codigo { get; set; }
        public virtual string Responsable { get; set; }
        public virtual DateTime FechaHoraDesde { set; get; }
        public virtual DateTime FechaHoraHasta { set; get; }
        public virtual string Observaciones { get; set; }
        public virtual double Seña { get; set; }

        public virtual Cancha Cancha { get; set; }
        public virtual UsuarioWeb UsuarioWeb { get; set; }
        public virtual UsuarioApp UsuarioApp { get; set; }
        public virtual EstadoTurno EstadoTurno { get; set; }
    }
}
