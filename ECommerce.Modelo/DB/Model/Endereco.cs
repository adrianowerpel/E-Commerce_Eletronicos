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
    public class Endereco
    {
        public virtual Guid idEndereco { get; set; }

        [Required(ErrorMessage = "A RUA é Obrigátoria!")]
        public virtual String rua { get; set; }

        [Required(ErrorMessage = "O BAIRRO é Obrigátorio!")]
        public virtual String bairro { get; set; }

        [Required(ErrorMessage = "A CIDADE é Obrigátoria!")]
        public virtual String cidade { get; set; }

        [Required(ErrorMessage = "O ENDEREÇO é Obrigátorio!")]
        [DataType(DataType.PostalCode)]
        public virtual String cep { get; set; }

        [Required(ErrorMessage = "O NUMERO é Obrigátorio!")]
        public virtual String numero { get; set; }

        public virtual Cliente cliente { get; set; }
        public virtual Fabricante fabricante { get; set; }
    }

    public class EnderecoMap : ClassMapping<Endereco>
    {
        public EnderecoMap()
        {
            Id(x => x.idEndereco, m => m.Generator(Generators.Guid));

            Property(x => x.rua);
            Property(x => x.bairro);
            Property(x => x.cidade);
            Property(x => x.cep);
            Property(x => x.numero);

            ManyToOne(x => x.cliente, m =>
            {
                m.Column("cliente_idCliente");
                m.Lazy(LazyRelation.NoLazy);
            });

            ManyToOne(x => x.fabricante, m =>
            {
                m.Column("fabricante_IdFabricante");
                m.Lazy(LazyRelation.NoLazy);
            });
        }
    }
}
