using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class Cancha
    {
        public virtual int Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual double PrecioMañana { get; set; }
        public virtual double PrecioTarde { get; set; }
        public virtual double PrecioNoche { get; set; }

        public virtual TipoCancha TipoCancha { get; set; }
        public virtual Complejo Complejo { get; set; }
    }
}
