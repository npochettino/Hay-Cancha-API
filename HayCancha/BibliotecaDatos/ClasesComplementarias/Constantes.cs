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
            public const int CERRADO = 5;
        }

        public class EstadosSolicitud
        {
            public const int PENDIENTE = 1;
            public const int ACEPTADA = 2;
            public const int RECHAZADA = 3;
        }

        public const string RutaImagenesUsuariosApp = "http://haycancha.sempait.com.ar/Imagenes/";
        public const string RutaImagenesComplejos = "http://haycancha.sempait.com.ar/ImagenesComplejos/";
        public const string RutaLogosComplejos = "http://haycancha.sempait.com.ar/ImagenesComplejos/Logos/";
    }
}
