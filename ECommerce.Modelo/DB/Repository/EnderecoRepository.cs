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
    public class EnderecoRepository : RepositoyBase<Endereco>
    {
        public EnderecoRepository(ISession session) : base(session) { }

        public IList<Endereco> GetAllByName(String rua)
        {
            try
            {
                return Session.Query<Endereco>().Where(w => w.rua.ToLower() == rua.Trim().ToLower()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conseguir encontrar a(s) pessoa(s) pelo(s) nome(s)", ex);
            }
        }
    }
}
