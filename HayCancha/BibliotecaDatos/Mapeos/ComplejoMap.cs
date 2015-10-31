using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class ComplejoMap : ClassMap<Complejo>
    {
        public ComplejoMap()
        {
            Table("Complejos");
            Id(x => x.Codigo).Column("codigoComplejo").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.Direccion).Column("direccion");
            Map(x => x.Telefono).Column("telefono");
            Map(x => x.Mail).Column("mail");
            Map(x => x.HoraApertura).Column("horaApertura");
            Map(x => x.HoraCierre).Column("horaCierre");
        }
    }
}
