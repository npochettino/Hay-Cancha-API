using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class CanchaMap : ClassMap<Cancha>
    {
        public CanchaMap()
        {
            Table("Canchas");
            Id(x => x.Codigo).Column("codigoCancha").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.PrecioMañana).Column("precioMañana");
            Map(x => x.PrecioTarde).Column("precioTarde");
            Map(x => x.PrecioNoche).Column("precioNoche");

            References(x => x.TipoCancha).Column("codigoTipoCancha").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
