using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaDatos.Mapeos
{
    class EstadoTurnoMap: ClassMap<EstadoTurno>
    {
        public EstadoTurnoMap()
        {
            Table("EstadosTurnos");
            Id(x => x.Codigo).Column("codigoEstado").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
