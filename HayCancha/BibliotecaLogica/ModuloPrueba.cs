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
            ControladorTurnos.RecuperarTurnosPorRangoHorario(DateTime.Now, 16, 20, 1);
        }
    }
}
