using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class SolicitudPendiente
    {
        public virtual int Codigo { get; set; }

        public virtual TurnoFijo TurnoFijo { get; set; }
        public virtual TurnoVariable TurnoVariable { get; set; }
        public virtual UsuarioApp UsuarioApp { get; set; }
    }
}
