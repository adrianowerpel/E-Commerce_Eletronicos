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
    public class ProdutoRepository : RepositoyBase<Produto>
    {

        public ProdutoRepository(ISession session) : base(session) { }

        public IList<Produto> GetAllByName(String nome)
        {
            try
            {
                return this.Session.Query<Produto>().Where(w => w.Nome.Contains(nome.Trim().ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar o produto!", ex);
            }
        }

        public IList<Produto> BuscarPelaDescricao(String descricao)
        {
            try
            {
                return this.Session.Query<Produto>().Where(x => x.Descricao.Contains(descricao.Trim().ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar o produto!", ex);
            }
        }

        public IList<Produto> BuscarPeloValor(Double valor)
        {
            try
            {
                return this.Session.Query<Produto>().Where(x => x.Valor == valor).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar o produto nesse valor!", ex);
            }
        }

        public IList<Produto> BuscarPeloIdFabricante(Guid id)
        {
            try
            {
                return this.Session.Query<Produto>().Where(x => x.fabricante.IdFabricante == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar um produto para este fabricante!", ex);
            }
        }
    }
}
