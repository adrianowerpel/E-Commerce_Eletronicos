using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Model
{
    public class Produto
    {
        public virtual Guid Id { get; set; }

        [Required(ErrorMessage = "O NOME é Obrigátorio!")]
        public virtual String Nome { get; set; }

        public virtual String Descricao { get; set; }

        [Required(ErrorMessage = "O PESO é Obrigátorio!")]
        public virtual Double Peso { get; set; }

        [Required(ErrorMessage = "O VALOR é Obrigátorio!")]
        [DataType(DataType.Currency)]
        public virtual Double Valor { get; set; }

        public virtual String Imagem { get; set; }

        [Required(ErrorMessage = "O ESTOQUE é Obrigátorio mesmo se 0!")]
        public virtual int Estoque { get; set; }

        public virtual Fabricante fabricante { get; set; }
        public virtual Produto produto { get; set; }
        public virtual IList<Carrinho> carrinho { get; set; }
        public virtual IList<HistoricoBusca> historicoBusca { get; set; }
        public virtual Lista_Compra Lista_Compra { get; set; }

        public Produto()
        {
            carrinho = new List<Carrinho>();
            historicoBusca = new List<HistoricoBusca>();
        }

    }

    public class ProdutoMap : ClassMapping<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
            Property(x => x.Descricao);
            Property(x => x.Valor);
            Property(x => x.Valor);
            Property(x => x.Imagem);
            Property(x => x.Estoque);
            Property(x => x.Peso);

            ManyToOne(x => x.fabricante, m =>
            {
                m.Column("fabricante_IdFabricante");
                m.Lazy(LazyRelation.NoLazy);
            });

            ManyToOne(x => x.Lista_Compra, m =>
            {
                m.Column("listaCompra_idProduto");
                m.Lazy(LazyRelation.NoLazy);
            });

            Bag(x => x.carrinho, m =>
            {
                m.Cascade(Cascade.DeleteOrphans);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("produto_IdProduto"));
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

            Bag(x => x.historicoBusca, m =>
            {
                m.Cascade(Cascade.DeleteOrphans);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("produto_IdProduto"));
                m.Inverse(true);
            },
                r => r.OneToMany()
            );
        }
    }
}
