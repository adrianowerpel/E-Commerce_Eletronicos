using ECommerce.Modelo.DB.Model;
using ECommerce.Modelo.DB.Repository;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Repository
{
    public class ClienteRepository : RepositoyBase<Cliente>
    {
        public ClienteRepository(ISession session) : base(session) { }

        public IList<Cliente> GetAllByName(String nome)
        {
            try
            {
                return Session.Query<Cliente>().Where(w => w.nome.ToLower() == nome.Trim().ToLower()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conseguir encontrar a(s) pessoa(s) pelo(s) nome(s)", ex);
            }
        }

        public Cliente BuscarPorIdLogin(Guid id)
        {
            try
            {
                return Session.Query<Cliente>().FirstOrDefault(w => w.login.idLogin == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conseguir encontrar a(s) pessoa(s) pelo(s) nome(s)", ex);
            }
        }
    }
}
