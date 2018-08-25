using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Model
{
    public class Lista_Compra
    {
        public virtual Guid idLista_compra { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
        public virtual Cliente Cliente { get; set; }

        public Lista_Compra()
        {
            Produtos = new List<Produto>();
        }
    }

    public class Lista_CompraMap : ClassMapping<Lista_Compra>
    {
        public Lista_CompraMap()
        {
            Id(x => x.idLista_compra, m => m.Generator(Generators.Guid));

            Bag(x => x.Produtos, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("listaCompra_idProduto"));
                m.Inverse(true);
            },
               r => r.OneToMany()
           );

            ManyToOne(x => x.Cliente, m =>
            {
                m.Column("listaCompra_idCliente");
                m.Lazy(LazyRelation.NoLazy);
            });

           

        }
    }
}
