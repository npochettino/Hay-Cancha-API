using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class SolicitudMap : ClassMap<Solicitud>
    {
        public SolicitudMap()
        {
            Table("SolicitudesPendientes");
            Id(x => x.Codigo).Column("codigoSolicitudPendiente").GeneratedBy.Identity();

            References(x => x.TurnoFijo).Column("codigoTurnoFijo").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.TurnoVariable).Column("codigoTurnoVariable").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.UsuarioAppInvitado).Column("codigoUsuarioApp").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.EstadoSolicitud).Column("codigoEstadoSolicitud").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
