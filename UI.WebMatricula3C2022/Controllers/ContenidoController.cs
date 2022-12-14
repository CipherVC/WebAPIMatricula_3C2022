using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class ContenidoController : Controller
    {

        LnContenido lnContenido = new LnContenido();
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Contenido.Entrada.VerTodosContenidos parametros =
                new Models.Contenido.Entrada.VerTodosContenidos();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaContenidos = await lnContenido.VerTodosContenidos(parametros, usuarioActual.Token);
            ////GRRAFICOS////
            var random = new Random();
            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaContenidos.ListaContenido.GroupBy(e => e.FechaCreacion.Day)
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

            return View(listaContenidos.ListaContenido);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarContenido(Models.Contenido.Entrada.AgregarContenido agregarContenido)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnContenido.AgregarContenido(agregarContenido, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El contenido: {0} ha sido ingresado con éxito.", agregarContenido.NombreArchivo));
            else
                return Json(String.Format("El contenido: {0} no fue ingresado.", agregarContenido.NombreArchivo));
        }

        [HttpPost]
        public async Task<JsonResult> EditarContenido(Models.Contenido.Entrada.EditarContenido editarContenido)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnContenido.EditarContenido(editarContenido, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El contenido: {0} ha sido modificado con éxito.", editarContenido.NombreArchivo));
            else
                return Json(String.Format("El contenido: {0} no fue modificado.", editarContenido.NombreArchivo));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarContenido(Models.Contenido.Entrada.EliminarContenido eliminarContenido)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnContenido.EliminarContenido(eliminarContenido, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El contenido: {0} ha sido eliminado con éxito.", eliminarContenido.Codigo));
            else
                return Json(String.Format("El contenido: {0} no fue eliminado.", eliminarContenido.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleContenido(Models.Contenido.Entrada.VerDetalleContenido verDetalleContenido)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnContenido.VerDetalleContenido(verDetalleContenido, usuarioActual.Token);

            return Json(respuesta);
        }
    }
}
