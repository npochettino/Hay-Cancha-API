using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    public class PosicionMap : ClassMap<Posicion>
    {
        public PosicionMap()
        {
            Table("Posiciones");
            Id(x => x.Codigo).Column("codigoPosicion").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
