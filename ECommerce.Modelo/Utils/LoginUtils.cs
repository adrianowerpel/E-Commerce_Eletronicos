using ECommerce.Modelo.DB;
using ECommerce.Modelo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerce.Modelo.Utils
{
    public class LoginUtils
    {
        public static Login Login
        {
            get
            {
                if (HttpContext.Current.Session["Login"] != null)
                {
                    return (Login)HttpContext.Current.Session["Login"];
                }

                return null;
            }
        }

        public static Cliente Cliente
        {
            get
            {
                if (HttpContext.Current.Session["Cliente"] != null)
                {
                    return (Cliente)HttpContext.Current.Session["Cliente"];
                }

                return null;
            }
        }

        public static IList<Carrinho> Carrinho
        {
            get
            {
                if (HttpContext.Current.Session["Carrinho"] != null)
                {
                    return (IList<Carrinho>)HttpContext.Current.Session["Carrinho"];
                }

                return null;
            }
        }


        public static void MeuCarrinho(IList<Carrinho> carrinho)
        {
             HttpContext.Current.Session["Carrinho"] = carrinho;            
        }

        //Faz a busca no bando de dados para saber se existe o usuário com login e senha digitados
        public static void Logar(String login, String senha)
        {
            var usuario = DbFactory.Instance.LoginRepository.Login(login, senha);
            var cliente = DbFactory.Instance.ClienteRepository.BuscarPorIdLogin(usuario.idLogin);

            if (usuario != null)
            {
                HttpContext.Current.Session["Login"] = usuario;
                HttpContext.Current.Session["Cliente"] = cliente;
            }
        }

        //Desloga o usuário limpando ele da sessão do navegador
        public static void Deslogar()
        {
            HttpContext.Current.Session["Login"] = null;
            HttpContext.Current.Session.Remove("Login");
            HttpContext.Current.Session["Cliente"] = null;
            HttpContext.Current.Session.Remove("Cliente");
            HttpContext.Current.Session["Carrinho"] = null;
            HttpContext.Current.Session.Remove("Carrinho");
        }
    }
}
