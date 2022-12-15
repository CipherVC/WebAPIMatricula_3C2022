using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using UI.WebMatricula3C2022.Logica;
using UI.WebMatricula3C2022.Models;
using UI.WebMatricula3C2022.Models.Users;

namespace UI.WebMatricula3C2022.Controllers
{
    public class AccesoController : Controller
    {
        public async Task<ActionResult> Index(Models.Users.AuthenticateModel pDatos)
        {
            if (!string.IsNullOrEmpty(pDatos.Username) && !string.IsNullOrEmpty(pDatos.Password))
            {
                UsersController usersController = new UsersController();
                var usuario = usersController.Authenticate(pDatos.Username, pDatos.Password);

                if (!string.IsNullOrEmpty(usuario.Result.Token))
                {

                    var claims = new List<Claim>
                    {
                        new Claim("Codigo", usuario.Result.Codigo.ToString()),
                        new Claim("Identificacion", usuario.Result.Identificacion),
                        new Claim("NombreCompleto", usuario.Result.NombreCompleto),
                        new Claim("CorreoElectronico", usuario.Result.CorreoElectronico),
                        new Claim("NumeroTelefono", usuario.Result.NombreCompleto),
                        new Claim("Username", usuario.Result.NombreCompleto),
                        new Claim("Estado", usuario.Result.NombreCompleto),
                        new Claim("Token", usuario.Result.Token)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.Session.SetObjectAsJson("UsuarioActual", usuario.Result);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LogOnError", "Credenciales incorrectas.");
                    return View("Index");
                }
            }
            else
                return View("Index");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }

        public IActionResult Registro()
        {
            return View();
        
        }
        [HttpPost]
        public async Task<IActionResult> Registro(string identificacion,string nombreCompleto, string correo,string numeroTelefono,string username,string password,string Estado) {
            RegisterModel model = new RegisterModel {
                Identificacion=identificacion,
                NombreCompleto=nombreCompleto,
                CorreoElectronico=correo,
                NumeroTelefono=numeroTelefono,
                Username=username,Password=password,
                Estado=Estado };
            UsersController controller = new UsersController();
            var response=await controller.Register(model);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
