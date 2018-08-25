using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Model
{
    public class HistoricoBusca
    {
        public virtual Guid IdHistorico { get; set; }
        public virtual DateTime DataHota { get; set; }
        public virtual Produto produto { get; set; }
        public virtual Cliente cliente { get; set; }
    }

    public class HistoricoBuscaMap : ClassMapping<HistoricoBusca>
    {
        public HistoricoBuscaMap()
        {
            Id(x => x.IdHistorico, m => m.Generator(Generators.Guid));

            Property(x => x.DataHota);

            ManyToOne(x => x.cliente, m =>
            {
                m.Column("cliente_idCliente");
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.Persist);
            });

            ManyToOne(x => x.produto, m =>
            {
                m.Column("produto_IdProduto");
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.Persist);
            });
        }


    }
}
