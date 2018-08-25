using ECommerce.Modelo.DB;
using ECommerce.Modelo.DB.Model;
using ECommerce.Modelo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{ 
    public class ClienteController : Controller
    {
        public static Login Login = new Login();
        public static Cliente Cliente = new Cliente();

        public void BuscarCliente(Guid id)
        {
            Cliente = DbFactory.Instance.ClienteRepository.FindById(id);
        }

        // GET: Cliente
        public ActionResult CadastrarLoginCliente()
        {
            return View(new Login());
        }
        
        public ActionResult GravarLoginCliente(Login log)
        {
            Login = log;

            DbFactory.Instance.LoginRepository.SaveOrUpdate(log);

            return RedirectToAction("CadastrarCliente");
        }

        public ActionResult CadastrarCliente()
        {
            return View(new Cliente());
        }

        public ActionResult GravarCliente(Cliente cli)
        {
            cli.login = Login;
            Cliente = cli;

            DbFactory.Instance.ClienteRepository.SaveOrUpdate(cli);

            Login = null;

            return RedirectToAction("CadastrarEndereco");
        }

        public ActionResult CadastrarEndereco()
        {
            return View(new Endereco());
        }

        public ActionResult GravarEndereco(Endereco end)
        {
            end.cliente = Cliente;

            DbFactory.Instance.EnderecoRepository.SaveOrUpdate(end);

            Cliente = null;

            return RedirectToAction("Login","Home");
        }

        public ActionResult EnderecosCliente()
        {
            Guid id = Cliente.idCliente;

            var endereco = DbFactory.Instance.EnderecoRepository.FindAll();
            IList<Endereco> end = new List<Endereco>();

            foreach(Endereco e in endereco)
            {
                if(e.cliente != null && e.cliente.idCliente == id)
                {
                    end.Add(e);
                }
            } 

            return View(end);
        }

        public ActionResult Logar(String usuario, String senha)
        {
            LoginUtils.Logar(usuario, senha);

            if (LoginUtils.Login.permissao == true)
            {
                return RedirectToAction("AreaAdministrador", "Admin");
            }
            else if (LoginUtils.Login.permissao == false)
            {
                if(LoginUtils.Carrinho != null)
                {
                    foreach(Carrinho c in LoginUtils.Carrinho)
                    {
                        c.Id = new Guid();
                        c.cliente = LoginUtils.Cliente;
                        DbFactory.Instance.CarrinhoRepository.SaveOrUpdate(c);
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Deslogar()
        {
            Cliente = null;
            LoginUtils.Deslogar();
            return RedirectToAction("Index","Home");
        }

        public ActionResult PreencherQuestionario()
        {
            return View(new Questionario());
        }

        public ActionResult GravarQuestionario(Questionario quest)
        {
            quest.Cliente = Cliente;

            DbFactory.Instance.QuestionarioRepository.SaveOrUpdate(quest);

            return RedirectToAction("Login", "Index");
        }

        public ActionResult HistoricoPesquisa()
        {
            Guid id = LoginUtils.Cliente.idCliente;

            var historico = DbFactory.Instance.HistoricoBuscaRepository.HistoricoDoCliente(id);

            return View(historico);
        }

        public ActionResult ApagarItemHistorico(HistoricoBusca hb)
        {
            DbFactory.Instance.HistoricoBuscaRepository.Delete(hb);

            return RedirectToAction("HistoricoPesquisa");
        }

        public ActionResult ApagarTodoHistorico()
        {
            Guid id = LoginUtils.Cliente.idCliente;
            
            DbFactory.Instance.HistoricoBuscaRepository.ApagarTodoHistorico(id);

            return RedirectToAction("Index","Home");
        }
    }
}