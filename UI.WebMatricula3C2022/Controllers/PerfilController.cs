using Microsoft.AspNetCore.Mvc;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Index()
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("usuarioActual");
            return View(usuarioActual);
        }
    }
}
