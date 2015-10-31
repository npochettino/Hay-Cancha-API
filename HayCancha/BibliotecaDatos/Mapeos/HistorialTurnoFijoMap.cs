using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class HistorialTurnoFijoMap : ClassMap<HistorialTurnoFijo>
    {
        public HistorialTurnoFijoMap()
        {
            Table("HistorialTurnosFijos");
            Id(x => x.Codigo).Column("codigoHistorialTurnoFijo").GeneratedBy.Identity();
            Map(x => x.FechaHoraDesde).Column("fechaHoraDesde");
            Map(x => x.FechaHoraHasta).Column("fechaHoraHasta");
            Map(x => x.Observaciones).Column("observacion");
            Map(x => x.Seña).Column("seña");

            References(x => x.EstadoTurno).Column("codigoEstado").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
