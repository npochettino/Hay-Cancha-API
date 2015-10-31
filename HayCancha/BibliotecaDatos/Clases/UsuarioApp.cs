using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
    public class UsuarioApp
    {
        public UsuarioApp()
        {
            Valoraciones = new List<ValoracionUsuarioApp>();
            ComplejosFravoritos = new List<Complejo>();
        }

        public virtual int Codigo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Contraseña { get; set; }
        public virtual string Telefono { get; set; }
        public virtual bool IsActivo { get; set; }

        public virtual Posicion Posicion { get; set; }
        public virtual IList<ValoracionUsuarioApp> Valoraciones { get; set; }
        public virtual IList<Complejo> ComplejosFravoritos { get; set; }
    }
}
