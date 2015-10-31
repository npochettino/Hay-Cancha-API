using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class TurnoFijoMap : ClassMap<TurnoFijo>
    {
        public TurnoFijoMap()
        {
            Table("TurnosFijos");
            Id(x => x.Codigo).Column("codigoTurnoFijo").GeneratedBy.Identity();
            Map(x => x.Responsable).Column("responsable");
            Map(x => x.CodigoDiaSemana).Column("codigoDiaSemana");
            Map(x => x.HoraDesde).Column("horaDesde");
            Map(x => x.HoraHasta).Column("horaHasta");
            Map(x => x.FechaDesde).Column("fechaDesde");
            Map(x => x.FechaHasta).Column("fechaHasta");
            Map(x => x.Seña).Column("seña");
            Map(x => x.CantidadJugadoresFaltantes).Column("cantidadJugadoresFaltantes");
            Map(x => x.Observaciones).Column("observacion");

            References(x => x.UsuarioWeb).Column("codigoUsuarioWeb").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.Cancha).Column("codigoCancha").Cascade.None().LazyLoad(Laziness.Proxy);

            HasMany<HistorialTurnoFijo>(x => x.HistorialTurnoFijo).Table("HistorialTurnosFijos").KeyColumn("codigoTurnoFijo").Cascade.None();
        }
    }
}
