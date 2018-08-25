using ECommerce.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Repository
{
   public class Lista_CompraRepository : RepositoyBase<Lista_Compra>
    {
         public Lista_CompraRepository(ISession session) : base(session) { }
    }
}
