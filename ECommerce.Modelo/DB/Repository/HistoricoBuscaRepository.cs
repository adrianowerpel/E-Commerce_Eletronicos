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
    public class HistoricoBuscaRepository : RepositoyBase<HistoricoBusca>
    {
        public HistoricoBuscaRepository(ISession session) : base(session) { }

        public IList<HistoricoBusca> HistoricoDoCliente(Guid id)
        {
            try
            {
                return this.Session.Query<HistoricoBusca>().Where(x => x.cliente.idCliente == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar um produto para este fabricante!", ex);
            }
        }

        public IList<HistoricoBusca> ApagarTodoHistorico(Guid id)
        {
            try
            {
                //var sql = "delete from {l} where cliente_idCliente = '"+id+"' ";
                //return this.Session.CreateSQLQuery(sql).List<HistoricoBusca>();

                var query = Session.CreateSQLQuery("delete from historicobusca where cliente_idCliente = '"+id+"'");

                query.AddEntity("l", typeof(HistoricoBusca));

                return query.List<HistoricoBusca>();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar um produto para este fabricante!", ex);
            }
        }
    }
}
