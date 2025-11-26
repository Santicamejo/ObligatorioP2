using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ObligatorioProg2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }

            Usuario elU = Sistema.Instancia.GetUsuarioPorEmail(HttpContext.Session.GetString("email"));

            ViewBag.Usuario = elU;
            ViewBag.GastosMes = Sistema.Instancia.SpentThisMonth(elU);


            if (HttpContext.Session.GetString("rol") == "Gerente")
            {
                List<Usuario> list = Sistema.Instancia.GetUsuariosPorEquipo(elU.Equipo.Nombre);
                ViewBag.ListadoEmpleados = list;
            }

            return View();
        }
    }
}
