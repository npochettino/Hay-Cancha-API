using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class Complejo
    {
        public virtual int Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Mail { get; set; }
        public virtual string HoraApertura { get; set; }
        public virtual string HoraCierre { get; set; }
        public virtual double Latitud { get; set; }
        public virtual double Longitud { get; set; }
    }
}
