using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
            ControladorGeneral.RecuperarSolicitudesPorUsuario(7, 0);
        }
    }
}
