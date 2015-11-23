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
            //ControladorTurnos.InsertarActualizarTurnoVariable(0, 1, Convert.ToDateTime("22/11/2015 11:00:00"), Convert.ToDateTime("22/11/2015 12:00:00"), 1, "", "", 13);
            //ControladorTurnos.InsertarActualizarTurnoVariable(0, 2, Convert.ToDateTime("22/11/2015 12:00:00"), Convert.ToDateTime("22/11/2015 13:00:00"), 1, "", "", 13);
            //ControladorTurnos.InsertarActualizarTurnoVariable(0, 5, Convert.ToDateTime("22/11/2015 13:00:00"), Convert.ToDateTime("22/11/2015 14:00:00"), 1, "", "", 13);
            //ControladorTurnos.InsertarActualizarTurnoVariable(0, 5, Convert.ToDateTime("22/11/2015 13:00:00"), Convert.ToDateTime("22/11/2015 14:00:00"), 1, "", "", 13);

            ControladorTurnos.RecuperarTurnosPorComplejoPorDia(DateTime.Now, 1);
        }
    }
}
