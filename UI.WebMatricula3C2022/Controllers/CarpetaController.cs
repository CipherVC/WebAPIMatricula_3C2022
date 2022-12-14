using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class CarpetaController : Controller
    {
        LnCarpeta lnCarpeta = new LnCarpeta();
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Carpeta.Entrada.VerTodosCarpeta parametros =
                new Models.Carpeta.Entrada.VerTodosCarpeta();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaCarpetas = await lnCarpeta.VerTodosCarpetas(parametros, usuarioActual.Token);
            ////GRRAFICOS////
            var random = new Random();
            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaCarpetas.ListaCarpeta.GroupBy(e => e.FechaCreacion.Day)
                .Select(group => new
                {
                    Estado = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Estado))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));
                etiquetas.Add(estado.Estado.ToString());
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }
            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);

            ///GRAFICOS///

            return View(listaCarpetas.ListaCarpeta);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarCarpeta(Models.Carpeta.Entrada.AgregarCarpeta agregarCarpeta)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCarpeta.AgregarCarpeta(agregarCarpeta, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El contenido: {0} ha sido ingresado con éxito.", agregarCarpeta.Nombre));
            else
                return Json(String.Format("El contenido: {0} no fue ingresado.", agregarCarpeta.Nombre));
        }

        [HttpPost]
        public async Task<JsonResult> EditarCarpeta(Models.Carpeta.Entrada.EditarCarpeta editarCarpeta)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCarpeta.EditarCarpeta(editarCarpeta, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El contenido: {0} ha sido modificado con éxito.", editarCarpeta.Nombre));
            else
                return Json(String.Format("El contenido: {0} no fue modificado.", editarCarpeta.Nombre));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarCarpeta(Models.Carpeta.Entrada.EliminarCarpeta eliminarCarpeta)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCarpeta.EliminarCarpeta(eliminarCarpeta, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El contenido: {0} ha sido eliminado con éxito.", eliminarCarpeta.Codigo));
            else
                return Json(String.Format("El contenido: {0} no fue eliminado.", eliminarCarpeta.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleCarpeta(Models.Carpeta.Entrada.VerDetalleCarpeta verDetalleCarpeta)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnCarpeta.VerDetalleCarpeta(verDetalleCarpeta, usuarioActual.Token);

            return Json(respuesta);
        }
    }
}
