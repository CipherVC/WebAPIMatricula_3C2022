using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class EstudianteController : Controller
    {



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            LnEstudiante lnEstudiante = new LnEstudiante();
            Models.Estudiante.Entrada.VerTodosEstudiantes parametro = new Models.Estudiante.Entrada.VerTodosEstudiantes();

            var usuario = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var listaEstudiantes = await lnEstudiante.VerTodosEstudiantes(parametro, usuario.Token);

            ////GRRAFICOS////
            var random= new Random();
            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach(var estado in listaEstudiantes.ListaEstudiantes.GroupBy(e=> e.Estado)
                .Select(group => new
            {
                Estado = group.Key,
                Cantidad =group.Count()
            }).OrderBy(x=> x.Estado))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));
                etiquetas.Add(estado.Estado);
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }
            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);  
            ViewBag.Valores = JsonConvert.SerializeObject(valores) ;  

            ///GRAFICOS///
            return View(listaEstudiantes.ListaEstudiantes);
        }
        [HttpPost]
        public async Task<JsonResult> AgregarEstudiante(Models.Estudiante.Entrada.AgregarEstudiante agregarEstudiante) {
            LnEstudiante lnEstudiante = new LnEstudiante();
            Models.Estudiante.Entrada.AgregarEstudiante parametro = new Models.Estudiante.Entrada.AgregarEstudiante();
            var usuario = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var agregarEstud = await lnEstudiante.AgregarEstudiante(parametro, usuario.Token);
            return Json(agregarEstud);
        }
    }
}
