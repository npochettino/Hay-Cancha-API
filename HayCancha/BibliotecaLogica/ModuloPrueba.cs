using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaLogica.Controladores;

namespace BibliotecaLogica
{
    class ModuloPrueba
    {
        static void Main()
        {
            //ControladorUsuarios.InsertarActualizarUsuarioApp(0, "Ezequiel", "Dalaison", "ezequieldalaison13@gmail.com", "444", "444", 1);
            //DataTable t = ControladorUsuarios.RecuperarUsuarioApp("ezequieldalaison13@gmail.com", "444");

            //ControladorUsuarios.InsertarNuevoUsuarioWebConComplejo("Ezequiel", "Canchero", "eze@gmail.com", "333", "Chacagol", "Chacabuco", "12:00", "00:00", "chaca@gmail.com", "424");
            DataTable t2 = ControladorUsuarios.RecuperarUsuarioWeb("eze@gmail.com", "333");
        }
    }
}
