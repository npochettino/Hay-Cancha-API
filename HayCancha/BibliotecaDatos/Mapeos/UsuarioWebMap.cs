using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class UsuarioWebMap : ClassMap<UsuarioWeb>
    {
        public UsuarioWebMap()
        {
            Table("UsuariosWeb");
            Id(x => x.Codigo).Column("codigoUsuarioWeb").GeneratedBy.Identity();
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Apellido).Column("apellido");
            Map(x => x.Mail).Column("mail");
            Map(x => x.Contraseña).Column("contraseña");

            References(x => x.Complejo).Column("codigoComplejo").Cascade.SaveUpdate().LazyLoad(Laziness.Proxy);
        }
    }
}
