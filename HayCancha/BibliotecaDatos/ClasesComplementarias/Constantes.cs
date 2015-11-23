using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos.ClasesComplementarias
{
    public class Constantes
    {
        public class EstadosTurno
        {
            public const int RESERVADO = 1;
            public const int CANCELADO = 2;
            public const int PENDIENTE = 3;
            public const int AUSENTE = 4;
        }

        public class EstadosSolicitud
        {
            public const int PENDIENTE = 1;
            public const int ACEPTADA = 2;
            public const int RECHAZADA = 3;
        }
    }
}
