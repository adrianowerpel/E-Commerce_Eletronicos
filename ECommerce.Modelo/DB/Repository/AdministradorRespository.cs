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
    public class AdministradorRespository : RepositoyBase<Administrador>
    {
        public AdministradorRespository(ISession session) : base(session) { }

        public IList<Administrador> GetAllByName(String nome)
        {
            try
            {
                return Session.Query<Administrador>().Where(w => w.nome.ToLower() == nome.Trim().ToLower()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conseguir encontrar a(s) pessoa(s) pelo(s) nome(s)", ex);
            }
        }
    }
}
