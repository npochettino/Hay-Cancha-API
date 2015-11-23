using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class Complejo
    {
        public Complejo()
        {
            ValoracionesComplejo = new List<ValoracionComplejo>();
        }

        public virtual int Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Mail { get; set; }
        public virtual int HoraApertura { get; set; }
        public virtual int HoraCierre { get; set; }
        public virtual double Latitud { get; set; }
        public virtual double Longitud { get; set; }
        public virtual string Logo { get; set; }

        public virtual IList<ValoracionComplejo> ValoracionesComplejo { get; set; }
    }
}
