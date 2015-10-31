using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.Clases
{
   public class UsuarioWeb
   {
       public virtual int Codigo { get; set; }
       public virtual string Nombre { get; set; }
       public virtual string Apellido { get; set; }
       public virtual string Mail { get; set; }
       public virtual string Contraseña { get; set; }

       public virtual Complejo Complejo { get; set; }
    }
}
