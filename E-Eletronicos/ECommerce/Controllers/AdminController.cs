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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AreaAdministrador()
        {
            return View();
        }

        public ActionResult ControleUsuarios()
        {
            var usuarios = DbFactory.Instance.ClienteRepository.FindAll();

            return View(usuarios);
        }

        public ActionResult EditarCliente(Guid id)
        {
            var cliente = DbFactory.Instance.ClienteRepository.FindById(id);

            if (cliente != null)
            {
                return View(cliente);
            }
            else
            {
                return RedirectToAction("ControleUsuarios");
            }
        }

        public ActionResult DetalhesCliente(Guid id)
        {
            var cliente = DbFactory.Instance.ClienteRepository.FindById(id);

            return View(cliente);
        }

        public ActionResult ApagarCliente(Guid id)
        {
            var cliente = DbFactory.Instance.ClienteRepository.FindById(id);

            var login = DbFactory.Instance.LoginRepository.FindById(cliente.login.idLogin);

            if (cliente != null)
                DbFactory.Instance.ClienteRepository.Delete(cliente);

            if (login != null)
                DbFactory.Instance.LoginRepository.Delete(login);

            return RedirectToAction("ControleUsuarios");
        }
    }
}