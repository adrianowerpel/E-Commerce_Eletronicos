using ECommerce.Modelo.DB;
using ECommerce.Modelo.DB.Model;
using ECommerce.Modelo.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult ControleProdutos()
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindAll();

            return View(produto);
        }

        public ActionResult DetalhesProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);

            return View(produto);
        }

        public ActionResult DetalhesProdutoCliente(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);

            return View(produto);
        }

        public ActionResult InserirProduto()
        {
            return View("EditarProduto",new Produto());
        }

        public ActionResult GravarProduto(Produto produto, HttpPostedFileBase imagem)
        {
            var caminho = "";

            if (imagem != null && imagem.ContentLength > 0)
            {
                caminho = Path.Combine(HttpContext.Server.MapPath("~/Images/Produtos/"), imagem.FileName);

                imagem.SaveAs(caminho);

                produto.Imagem = imagem.FileName;
            }

            DbFactory.Instance.ProdutoRepository.SaveOrUpdate(produto);

            return RedirectToAction("ControleProdutos");
        }

        public ActionResult EditarProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);

            if (produto != null)
            {
                return View(produto);
            }
            else
            {
                return RedirectToAction("ControleProdutos");
            }
        }

        public ActionResult ApagarProduto(Guid id)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);

            if (produto != null)
                DbFactory.Instance.ProdutoRepository.Delete(produto);

            return RedirectToAction("ControleProdutos");
        }

        public ActionResult VenderProduto()
        {          
            var cliente = DbFactory.Instance.ClienteRepository.FindById(LoginUtils.Cliente.idCliente);

            var lista = new Lista_Compra();
            lista.Cliente = cliente;
            var carrinho = DbFactory.Instance.CarrinhoRepository.PorCliente(LoginUtils.Cliente.idCliente);
            
            foreach(Carrinho c in carrinho)
            {
                lista.Produtos.Add(c.produto);
            }

                foreach (var prod in lista.Produtos)
                {
                   var produto =  DbFactory.Instance.ProdutoRepository.FindById(prod.Id);
                    produto.Estoque--;
                    DbFactory.Instance.ProdutoRepository.SaveOrUpdate(produto);
                }           
                

            return RedirectToAction("Index","Home",null);
        }



    }
}