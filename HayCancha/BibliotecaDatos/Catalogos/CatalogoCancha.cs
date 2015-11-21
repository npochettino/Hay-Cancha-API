using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using BibliotecaDatos.ClasesComplementarias;
using NHibernate;

namespace BibliotecaDatos.Catalogos
{
    public class CatalogoCancha : CatalogoGenerico<Cancha>
    {
        public static List<Cancha> RecuperarPorCodigoComplejo(int codigoComplejo, ISession nhSesion)
        {
            try
            {
                List<Cancha> listaCanchas = CatalogoGenerico<Cancha>.RecuperarLista(x => x.Complejo.Codigo == codigoComplejo, nhSesion);
                return listaCanchas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
