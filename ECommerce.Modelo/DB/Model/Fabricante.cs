using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Model
{
    public class Fabricante
    {
        public virtual Guid IdFabricante { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Cnpj { get; set; }
        public virtual String Telefone { get; set; }
        public virtual IList<Endereco> Endereco { get; set; }
        public virtual IList<Produto> Produtos { get; set; }

        public Fabricante()
        {
            Endereco = new List<Endereco>();
        }
    }
    public class FabricanteMap : ClassMapping<Fabricante>
    {
        public FabricanteMap()
        {
            Id(x => x.IdFabricante, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
            Property(x => x.Cnpj, m => { m.Unique(true); m.NotNullable(true); });
            Property(x => x.Telefone);


            Bag(x => x.Endereco, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("fabricante_IdFabricante"));
                m.Inverse(true);
            },
               r => r.OneToMany()
           );

            Bag(x => x.Produtos, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("fabricante_IdFabricante"));
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

        }
    }

}
