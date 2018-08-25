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
    public class CarrinhoController : Controller
    {
        public  static IList<Carrinho> Carrinho = new List<Carrinho>();

        // GET: Carrinho
        public ActionResult MeuCarrinho()
        {
            if (LoginUtils.Cliente != null)
            {
                var carrinho = DbFactory.Instance.CarrinhoRepository.PorCliente(LoginUtils.Cliente.idCliente);
                return View(carrinho);
            }
            else
            {
                return View(Carrinho);
            }
        }

        public ActionResult ColocarProdutoCarrinho(Guid id,int qtd)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);
            Carrinho carrinho = new Carrinho();
            carrinho.Id = Guid.NewGuid();
            carrinho.quantidade = qtd;
            carrinho.produto = produto;

            if (LoginUtils.Cliente != null)
            {
                carrinho.Id = new Guid();
                carrinho.cliente = LoginUtils.Cliente;
                DbFactory.Instance.CarrinhoRepository.SaveOrUpdate(carrinho);
            }

            Carrinho.Add(carrinho);

            LoginUtils.MeuCarrinho(Carrinho);

            return RedirectToAction("MeuCarrinho");
        }

        public ActionResult DetalhesProdutoCarrinho(Guid id)
        {
            Produto prod = DbFactory.Instance.ProdutoRepository.FindById(id);

            return View(prod);
        }

        public ActionResult AtualizarProdutoCarrinho(Guid id, int qtd)
        {
            var produto = DbFactory.Instance.ProdutoRepository.FindById(id);

            Carrinho Aux = new Carrinho();

            foreach(Carrinho c in Carrinho)
            {
                if(produto.Id == c.produto.Id)
                {
                    Aux = c;
                }
            }

            Carrinho.Remove(Aux);
            Aux.quantidade = qtd;
            Aux.produto = produto;
            Carrinho.Add(Aux);

            LoginUtils.MeuCarrinho(Carrinho);

            return RedirectToAction("MeuCarrinho");
        }

        public ActionResult ApagarProdutoCarrinho(Carrinho carrinho)
        {
            if (LoginUtils.Cliente != null)
            {
                DbFactory.Instance.CarrinhoRepository.Delete(carrinho);
            }
            else
            {
                Carrinho produto = new Carrinho();

                foreach(Carrinho c in Carrinho)
                {
                    if(c.Id == carrinho.Id)
                    {
                        produto = c;
                    }
                }

                Carrinho.Remove(produto);
            }

            LoginUtils.MeuCarrinho(Carrinho);

            return RedirectToAction("MeuCarrinho");
        }
    }
}