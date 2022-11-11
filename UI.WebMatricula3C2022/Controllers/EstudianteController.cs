using Microsoft.AspNetCore.Mvc;
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
            return View(listaEstudiantes.ListaEstudiantes);
        }
        [HttpPost]
        public async Task<JsonResult> AgregarEstudiante(Models.Estudiante.Entrada.AgregarEstudiante agregarEstudiante) { 
                var
        }
    }
}
