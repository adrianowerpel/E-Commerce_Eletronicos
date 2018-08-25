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
    public class FabricanteRepository : RepositoyBase<Fabricante>
    {
         public FabricanteRepository(ISession session) : base(session) { }

        public IList<Fabricante> GetAllByName(String nome)
        {
            try
            {
                return this.Session.Query<Fabricante>().Where(w => w.Nome.Contains(nome.Trim().ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar o produto!", ex);
            }
        }
    }
}
