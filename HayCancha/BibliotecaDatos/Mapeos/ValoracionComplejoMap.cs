using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    public class ValoracionComplejoMap : ClassMap<ValoracionComplejo>
    {
        public ValoracionComplejoMap()
        {
            Table("ValoracionesComplejos");
            Id(x => x.Codigo).Column("codigoValoracionComplejo").GeneratedBy.Identity();
            Map(x => x.Comentario).Column("comentario");
            Map(x => x.Puntaje).Column("puntaje");
            Map(x => x.Titulo).Column("titulo");
            Map(x => x.FechaHoraValoracionComplejo).Column("fechaHoraValoracion");

            References(x => x.UsuarioApp).Column("codigoUsuarioApp").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
