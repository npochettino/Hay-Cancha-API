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
            ControladorTurnos.RecuperarTurnosPorRangoHorario(Convert.ToDateTime("2015-10-31"), 15, 18, 1);
        }
    }
}
