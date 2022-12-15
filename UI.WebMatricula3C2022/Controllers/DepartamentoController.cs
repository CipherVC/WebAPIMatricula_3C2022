using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class DepartamentoController : Controller
    {
        LnDepartamento lnDepartamento = new LnDepartamento();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Departamento.Entrada.VerTodosDepartamentos parametros =
                new Models.Departamento.Entrada.VerTodosDepartamentos();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaDepartamentos = await lnDepartamento.VerTodosDepartamentos(parametros, usuarioActual.Token);
            ////GRRAFICOS////
            var random = new Random();
            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var nombreDepartamento in listaDepartamentos.ListaDepartamentos.GroupBy(e => e.NombreDepartamento)
                .Select(group => new
                {
                    NombreDepartamento = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.NombreDepartamento))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));
                etiquetas.Add(nombreDepartamento.NombreDepartamento);
                valores.Add(nombreDepartamento.Cantidad.ToString());
                colores.Add(color);
            }
            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);

            ///GRAFICOS///

            return View(listaDepartamentos.ListaDepartamentos);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarDepartamento(Models.Departamento.Entrada.AgregarDepartamento agregarDepartamento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnDepartamento.AgregarDepartamento(agregarDepartamento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Departamento: {0} ha sido ingresado con éxito.", agregarDepartamento.NombreDepartamento));
            else
                return Json(String.Format("El Departamento: {0} no fue ingresado.", agregarDepartamento.NombreDepartamento));
        }

        [HttpPost]
        public async Task<JsonResult> EditarDepartamento(Models.Departamento.Entrada.EditarDepartamento editarDepartamento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnDepartamento.EditarDepartamento(editarDepartamento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Departamento: {0} ha sido modificado con éxito.", editarDepartamento.NombreDepartamento));
            else
                return Json(String.Format("El Departamento: {0} no fue modificado.", editarDepartamento.NombreDepartamento));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarDepartamento(Models.Departamento.Entrada.EliminarDepartamento eliminarDepartamento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnDepartamento.EliminarDepartamento(eliminarDepartamento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Departamento: {0} ha sido eliminado con éxito.", eliminarDepartamento.Codigo));
            else
                return Json(String.Format("El Departamento: {0} no fue eliminado.", eliminarDepartamento.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleDepartamento(Models.Departamento.Entrada.VerDetalleDepartamento verDetalleDepartamento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnDepartamento.VerDetalleDepartamento(verDetalleDepartamento, usuarioActual.Token);

            return Json(respuesta);
        }
    }
}