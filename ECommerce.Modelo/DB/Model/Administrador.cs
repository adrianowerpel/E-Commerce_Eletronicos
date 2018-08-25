using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Model
{
    public class Administrador
    {
        public virtual Guid idAdministrador { get; set; }
        public virtual Guid relatorio_idRelatorio { get; set; }
        public virtual String nome { get; set; }
        public virtual String sobrenome { get; set; }
        public virtual String cpf { get; set; }

        public class AdministradorMap : ClassMapping<Administrador>
        {
            public AdministradorMap()
            {
                Id(x => x.idAdministrador, m => m.Generator(Generators.Guid));

                Property(x => x.nome);
                Property(x => x.sobrenome);
                Property(x => x.cpf, m => { m.Unique(true); m.NotNullable(true); });
            }
        }
    }
}
