using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BibliotecaDatos.ClasesComplementarias
{
    public class ManejoNHibernate
    {
        private static ISessionFactory singleton;
        private static ISessionFactory CrearSesion()
        {
            try
            {

                if (singleton == null)
                {
                    singleton = Fluently.Configure()
                      .Database(MsSqlConfiguration.MsSql2008
                      .ConnectionString("data source=localhost;initial catalog=HayCancha;Integrated Security=SSPI;"))
                      //.ConnectionString("data source=localhost;initial catalog=w1402088_HayCancha;user=w1402088_HayCancha;password=Algoritmos2015;"))
                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                      .BuildSessionFactory();
                }

                return singleton;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ISession IniciarSesion()
        {
            return CrearSesion().OpenSession();
        }
    }
}
