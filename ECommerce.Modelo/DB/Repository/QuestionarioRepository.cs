using ECommerce.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Repository
{
    public class QuestionarioRepository : RepositoyBase<Questionario>
    {
        public QuestionarioRepository(ISession session) : base(session) { }


    }
}