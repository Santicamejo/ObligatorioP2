using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ObligatorioProg2.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult MyPayments()
        {
            var email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver la pagina de 'Mis pagos'";
                return RedirectToAction("Login", "Home");
            }

            List<Pago> listaPagosFiltrada = Sistema.Instancia.GetPagosDelMesActualPorEmail(email);

            return View(listaPagosFiltrada);
        }


        public IActionResult AllPayments(int? mes, int? anio)
        {
            var email = HttpContext.Session.GetString("email");
            var rol = HttpContext.Session.GetString("rol");

            if (email == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }
            else if (rol != "Gerente")
            {
                TempData["FaltaRol"] = "Debes ser Gerente para ver la lista de pagos";
                return RedirectToAction("Index", "Home");
            }

            Usuario usuLogeado = Sistema.Instancia.GetUsuarioPorEmail(email);

            DateTime hoy = DateTime.Today;
            int mesBuscado = mes.GetValueOrDefault(hoy.Month);
            int anioBuscado = anio.GetValueOrDefault(hoy.Year);

            DateTime inicioMes = new DateTime(anioBuscado, mesBuscado, 1);
            DateTime finMes = new DateTime(anioBuscado, mesBuscado, DateTime.DaysInMonth(anioBuscado, mesBuscado));

            List<Pago> pagosEquipoFiltrados =
                Sistema.Instancia.GetPagosEquipoPorPeriodo(usuLogeado.Equipo.Nombre, inicioMes, finMes);

            ViewBag.Mes = mesBuscado;
            ViewBag.Anio = anioBuscado;

            return View(pagosEquipoFiltrados);
        }


        public IActionResult SelectPaymentType()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public IActionResult CreateSinglePayment()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }

            ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGasto();
            return View();
        }


        [HttpPost]
        public IActionResult CreateSinglePayment(PagoUnico pago, string tipoGastoNombre)
        {
            var email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }

            try
            {
                pago.Usuario = Sistema.Instancia.GetUsuarioPorEmail(email);
                pago.TipoGasto = Sistema.Instancia.GetTipoGastoPorNombre(tipoGastoNombre);
                Sistema.Instancia.AgregarPago(pago);
                ViewBag.Exito = "Pago registrado con éxito!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGasto();
                return View(pago);
            }

            ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGasto();
            return View();
        }


        public IActionResult CreateRecurrentPayment()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }

            ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGasto();
            return View();
        }


        [HttpPost]
        public IActionResult CreateRecurrentPayment(PagoRecurrente pago, string tipoGastoNombre)
        {
            var email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }

            try
            {
                pago.Usuario = Sistema.Instancia.GetUsuarioPorEmail(email);
                pago.TipoGasto = Sistema.Instancia.GetTipoGastoPorNombre(tipoGastoNombre);
                Sistema.Instancia.AgregarPago(pago);
                ViewBag.Exito = "Pago registrado con éxito!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGasto();
                return View(pago);
            }

            ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGasto();
            return View();
        }

    }
}