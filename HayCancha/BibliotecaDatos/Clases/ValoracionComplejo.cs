using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class ValoracionComplejo
    {
        public virtual int Codigo { get; set; }
        public virtual int Puntaje { get; set; }
        public virtual string Comentario { get; set; }
        public virtual DateTime FechaHoraValoracionComplejo { get; set; }
        public virtual string Titulo { get; set; }

        public virtual UsuarioApp UsuarioApp { get; set; }
    }
}
