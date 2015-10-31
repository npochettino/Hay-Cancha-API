using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    public class TipoCanchaMap : ClassMap<TipoCancha> //ES UNA TABLA ???? O CLASE CONSTANTE ????
    {
        public TipoCanchaMap()
        {
            Table("TiposCanchas");
            Id(x => x.Codigo).Column("codigoTipoCancha").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
