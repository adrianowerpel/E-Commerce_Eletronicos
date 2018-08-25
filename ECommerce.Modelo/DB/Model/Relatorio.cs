using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Model
{
    public class Relatorio
    {
        public virtual Guid idRelatorio { get; set; }
        public virtual String descricao { get; set; }
    }
}
