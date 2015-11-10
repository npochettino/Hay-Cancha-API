using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class TurnoVariableMap : ClassMap<TurnoVariable>
    {
        public TurnoVariableMap()
        {
            Table("TurnosVariables");
            Id(x => x.Codigo).Column("codigoTurnoVariable").GeneratedBy.Identity();
            Map(x => x.Responsable).Column("responsable");
            Map(x => x.FechaHoraDesde).Column("fechaHoraDesde");
            Map(x => x.FechaHoraHasta).Column("fechaHoraHasta");
            Map(x => x.Seña).Column("seña");
            Map(x => x.Observaciones).Column("observacion");

            References(x => x.UsuarioWeb).Column("codigoUsuarioWeb").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.EstadoTurno).Column("codigoEstado").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.UsuarioApp).Column("codigoUsuarioApp").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.Cancha).Column("codigoCancha").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
