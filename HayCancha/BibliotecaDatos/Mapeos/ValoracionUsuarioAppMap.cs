using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class ValoracionUsuarioAppMap : ClassMap<ValoracionUsuarioApp>
    {
        public ValoracionUsuarioAppMap()
        {
            Table("ValoracionesUsuariosApp");
            Id(x => x.Codigo).Column("codigoValoracionUsuarioApp").GeneratedBy.Identity();
            Map(x => x.Puntaje).Column("puntaje");
            Map(x => x.Comentario).Column("comentario");

            References(x => x.UsuarioAppEvaluador).Column("codigoUsuarioAppEvaluador").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
