using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class SolicitudPendienteMap : ClassMap<SolicitudPendiente>
    {
        public SolicitudPendienteMap()
        {
            Table("SolicitudesPendientes");
            Id(x => x.Codigo).Column("codigoSolicitudPendiente").GeneratedBy.Identity();

            References(x => x.TurnoFijo).Column("codigoTurnoFijo").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.TurnoVariable).Column("codigoTurnoVariable").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.UsuarioApp).Column("codigoUsuarioApp").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
