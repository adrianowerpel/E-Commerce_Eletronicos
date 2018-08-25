using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Model
{
    public class Carrinho
    {
        public virtual Guid Id { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Produto produto { get; set; }
        public virtual int quantidade { get; set; }

        public class ClassMapping : ClassMapping<Carrinho>
        {
            public ClassMapping()
            {
                Id(x => x.Id, m => m.Generator(Generators.Guid));

                Property(x => x.quantidade);

                ManyToOne(x => x.cliente, m =>
                {
                    m.Column("cliente_IdCliente");
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
}
