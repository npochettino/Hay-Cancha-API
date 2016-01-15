using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class UsuarioAppMap : ClassMap<UsuarioApp>
    {
        public UsuarioAppMap()
        {
            Table("UsuariosApp");
            Id(x => x.Codigo).Column("codigoUsuarioApp").GeneratedBy.Identity();
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Apellido).Column("apellido");
            Map(x => x.Mail).Column("mail");
            Map(x => x.Contraseña).Column("contraseña");
            Map(x => x.IsActivo).Column("isActivo");
            Map(x => x.Telefono).Column("telefono");
            Map(x => x.CodigoTelefono).Column("codigoTelefono");

            References(x => x.Posicion).Column("codigoPosicion").Cascade.None().LazyLoad(Laziness.Proxy);
            HasMany<ValoracionUsuarioApp>(x => x.Valoraciones).Table("ValoracionesUsuariosApp").KeyColumn("codigoUsuarioAppEvaluado").Cascade.AllDeleteOrphan();
            HasManyToMany<Complejo>(x => x.ComplejosFravoritos).Table("ComplejosFavoritos").ParentKeyColumn("codigoUsuarioApp").ChildKeyColumn("codigoComplejo").Cascade.AllDeleteOrphan();
        }
    }
}
