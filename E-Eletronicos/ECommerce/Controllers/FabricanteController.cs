using ECommerce.Modelo.DB;
using ECommerce.Modelo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class FabricanteController : Controller
    {

        public static Produto Produto = new Produto();

        public void BuscarProduto(Guid id)
        {
            Produto = DbFactory.Instance.ProdutoRepository.FindById(id);
        }

        public ActionResult ControleFabricantes()
        {
            var fabricantes = DbFactory.Instance.FabricanteRepository.FindAll();

            return View(fabricantes);
        }

        public ActionResult DetalhesFabricante(Guid id)
        {
            var fab = DbFactory.Instance.FabricanteRepository.FindById(id);

            return View(fab);
        }

        public ActionResult InserirFabricante()
        {
            return View("EditarFabricante", new Fabricante());
        }

        public ActionResult GravarFabricante(Fabricante fab)
        {
            DbFactory.Instance.FabricanteRepository.SaveOrUpdate(fab);

            return RedirectToAction("ControleFabricantes");
        }

        public ActionResult EditarFabricante(Guid id)
        {
            var fab = DbFactory.Instance.FabricanteRepository.FindById(id);

            if (fab != null)
            {
                return View(fab);
            }
            else
            {
                return RedirectToAction("ControleFabricantes");
            }
        }

        public ActionResult ApagarFabricante(Guid id)
        {
            var fab = DbFactory.Instance.FabricanteRepository.FindById(id);

            if (fab != null)
                DbFactory.Instance.FabricanteRepository.Delete(fab);

            return RedirectToAction("ControleFabricantes");
        }

        public ActionResult InserirFabricanteNoProduto(Fabricante fab)
        {
            Produto prod = new Produto();

            prod.fabricante = fab;

            return View(prod);
        }

        public ActionResult SetarFabricanteProduto(Guid id)
        {
            var fabricante = DbFactory.Instance.FabricanteRepository.FindById(id);
            Produto.fabricante = fabricante;

            DbFactory.Instance.ProdutoRepository.SaveOrUpdate(Produto);

            return RedirectToAction("ControleProdutos","Produto");
        }
    }
}