using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class Solicitud
    {
        public virtual int Codigo { get; set; }

        public virtual TurnoFijo TurnoFijo { get; set; }
        public virtual TurnoVariable TurnoVariable { get; set; }
        public virtual UsuarioApp UsuarioAppInvitado { get; set; }
        public virtual EstadoSolicitud EstadoSolicitud { get; set; }
    }
}
