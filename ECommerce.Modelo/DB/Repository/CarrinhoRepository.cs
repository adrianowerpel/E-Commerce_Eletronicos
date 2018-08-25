using ECommerce.Modelo.DB.Model;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Repository
{
    public class CarrinhoRepository : RepositoyBase<Carrinho>
    {
        public CarrinhoRepository(ISession session) : base(session) { }

        public IList<Carrinho> PorCliente(Guid id)
        {
            try
            {
                return this.Session.Query<Carrinho>().Where(x => x.cliente.idCliente == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar o produto!", ex);
            }
        }
    }
}
