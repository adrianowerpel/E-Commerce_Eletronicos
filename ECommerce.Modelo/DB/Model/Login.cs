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
    public class Login
    {
        public virtual Guid idLogin { get; set; }

        [Required(ErrorMessage = "O USUARIO é Obrigátorio!")]
        public virtual String usuario { get; set; }

        [Required(ErrorMessage = "A SENHA é Obrigátoria!")]
        [DataType(DataType.Password)]
        public virtual String senha { get; set; }

        public virtual Boolean permissao { get; set; }
        public virtual IList<Cliente> cliente { get; set; }

        public Login()
        {
            cliente = new List<Cliente>();
        }
    }

    public class LoginMap : ClassMapping<Login>
    {
        public LoginMap()
        {
            Id(x => x.idLogin, m => m.Generator(Generators.Guid));

            Property(x => x.usuario, m => { m.Unique(true); });
            Property(x => x.senha);

            Bag(x => x.cliente, m =>
            {
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("idLogin_cliente"));
                m.Inverse(true);
            },
                r => r.OneToMany()
            );
        }
    }
}
