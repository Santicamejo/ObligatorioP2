using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ObligatorioProg2.Controllers
{
    public class ExpensesController : Controller
    {
        public IActionResult AllExpenses()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver los Gastos";
                return RedirectToAction("Login", "Home");
            }
            else if (HttpContext.Session.GetString("rol") != "Gerente")
            {
                TempData["FaltaRol"] = "Debes ser Gerente para ver los Gastos";
                return RedirectToAction("Index", "Home");
            }

            List<TipoGasto> listaGastos = Sistema.Instancia.GetTipoGasto();

            return View(listaGastos);
        }

        public IActionResult NewExpense()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para agregar un gasto";
                return RedirectToAction("Login", "Home");
            }
            else if (HttpContext.Session.GetString("rol") != "Gerente")
            {
                TempData["FaltaRol"] = "Debes ser Gerente para agregar un gasto";
                return RedirectToAction("Index", "Home");
            }
            return View(new TipoGasto());
        }

        [HttpPost]
        public IActionResult NewExpense(TipoGasto nuevoTipoGasto)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para agregar un gasto";
                return RedirectToAction("Login", "Home");
            }
            else if (HttpContext.Session.GetString("rol") != "Gerente")
            {
                TempData["FaltaRol"] = "Debes ser Gerente para agregar un gasto";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                Sistema.Instancia.AgregarTipoGasto(nuevoTipoGasto);
                return RedirectToAction("AllExpenses");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(nuevoTipoGasto);
            }        
        }

        public IActionResult DeleteExpense()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para eliminar un gasto";
                return RedirectToAction("Login", "Home");
            }
            else if (HttpContext.Session.GetString("rol") != "Gerente")
            {
                TempData["FaltaRol"] = "Debes ser Gerente para eliminar un gasto";
                return RedirectToAction("Index", "Home");
            }

            List<TipoGasto> listaGastos = Sistema.Instancia.GetTipoGasto();

            return View(listaGastos);
        }

        [HttpPost]
        public IActionResult DeleteExpense(string nombre)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para eliminar un gasto";
                return RedirectToAction("Login", "Home");
            }
            else if (HttpContext.Session.GetString("rol") != "Gerente")
            {
                TempData["FaltaRol"] = "Debes ser Gerente para eliminar un gasto";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                Sistema.Instancia.EliminarTipoGastoPorNombre(nombre);
                return RedirectToAction("AllExpenses");
            }
            catch (Exception ex)
            {
                List<TipoGasto> listaGastos = Sistema.Instancia.GetTipoGasto();

                ViewBag.Error = ex.Message;
                return View(listaGastos);
            }   
        }

    }
}
