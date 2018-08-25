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
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindAll();

            return View(produto);
        }

        public ActionResult DetalhesProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);

            return View(produto);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Buscar(String pesquisa,String tipo)
        {
            IList<Produto> produtos = new List<Produto>(); 

            if (String.IsNullOrEmpty(pesquisa))
            {
                return RedirectToAction("Index");
            }

            if(tipo == "descricao")
            {
                produtos = DbFactory.Instance.ProdutoRepository.BuscarPelaDescricao(pesquisa);
            }
            else if(tipo == "valor")
            {
                produtos = DbFactory.Instance.ProdutoRepository.BuscarPeloValor(Convert.ToDouble(pesquisa));
            }
            else if(tipo == "fabricante")
            {
                var fabricantes = DbFactory.Instance.FabricanteRepository.GetAllByName(pesquisa);

                foreach (Fabricante f in fabricantes)
                {
                    produtos = DbFactory.Instance.ProdutoRepository.BuscarPeloIdFabricante(f.IdFabricante);
                }
            }
            else
            {
                produtos = DbFactory.Instance.ProdutoRepository.GetAllByName(pesquisa);
            }

            if (LoginUtils.Cliente != null)
            {
                foreach (Produto p in produtos)
                {
                    HistoricoBusca historico = new HistoricoBusca();
                    historico.DataHota = DateTime.Now ;
                    historico.cliente = LoginUtils.Cliente;
                    historico.produto = p;
                    DbFactory.Instance.HistoricoBuscaRepository.SaveOrUpdate(historico);
                }
            }

            return View("Index", produtos);
        }
    }
}