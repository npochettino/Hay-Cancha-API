using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    public class EstadoSolicitudMap : ClassMap<EstadoSolicitud>
    {
        public EstadoSolicitudMap()
        {
            Table("EstadosSolicitudes");
            Id(x => x.Codigo).Column("codigoEstadoSolicitud").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
