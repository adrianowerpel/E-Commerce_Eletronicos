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
    public class Cliente
    {
        public virtual Guid idCliente { get; set; }
        public virtual Guid lista_compra_idLista_compra { get; set; }

        [Required(ErrorMessage = "O NOME é Obrigátorio!")]
        [DataType(DataType.Currency)]
        public virtual String nome { get; set; }

        [Required(ErrorMessage = "O SOBRENOME é Obrigátorio!")]
        [DataType(DataType.Currency)]
        public virtual String sobrenome { get; set; }

        [Required(ErrorMessage = "O CPF é Obrigátorio!")]
        [DataType(DataType.Currency)]
        public virtual String cpf { get; set; }

        [Required(ErrorMessage = "O TELEFONE é Obrigátorio!")]
        [DataType(DataType.PhoneNumber)]
        public virtual String telefone { get; set; }

        [Required(ErrorMessage = "O EMAIL é Obrigátorio!")]
        [DataType(DataType.EmailAddress)]
        public virtual String email { get; set; }

        public virtual Login login { get; set; }
        public virtual IList<Carrinho> carrinho { get; set; }
        public virtual IList<Endereco> endereco { get; set; }
        public virtual IList<HistoricoBusca> historicoBusca { get; set; }
        public virtual IList<Lista_Compra> Lista_Compra { get; set; }

        public Cliente()
        {
            endereco = new List<Endereco>();
            carrinho = new List<Carrinho>();
            historicoBusca = new List<HistoricoBusca>();
            Lista_Compra = new List<Lista_Compra>();
        }
    }

    public class ClienteMap : ClassMapping<Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.idCliente, m => m.Generator(Generators.Guid));

            Property(x => x.nome);
            Property(x => x.sobrenome);
            Property(x => x.cpf, m => { m.Unique(true); m.NotNullable(true); });
            Property(x => x.telefone);
            Property(x => x.email);

            //Cliente pode ter apenas 1 login(Login_Cliente)
            ManyToOne(x => x.login, m =>
            {
                m.Column("idLogin_cliente");
                m.Unique(true);
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.Persist);
            });

            Bag(x => x.Lista_Compra, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("listaCompra_idCliente"));
                m.Inverse(true);
            },
               r => r.OneToMany()
           );


            Bag(x => x.endereco, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("cliente_idCliente"));
                m.Inverse(true);
            },
                r => r.OneToMany()
            );


            Bag(x => x.carrinho, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("cliente_idCliente"));
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

            Bag(x => x.historicoBusca, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("cliente_idCliente"));
                m.Inverse(true);
            },
                r => r.OneToMany()
            );
        }
    }

}
