using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Bll.Contenido;
using API.Bll.Contenido.Interfaces;

namespace WebAPIMatricula_3C2022.Controllers
{
    [Route("api/v1"+"/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ContenidoController : Controller
    {
        private LnContenido oLnContenido;
        public ContenidoController(IAdContenido accesoAdContenido)
        {
            oLnContenido = new LnContenido(accesoAdContenido);

        }
        [HttpPost]
        [Route("AgregarContenido")]
        public IActionResult AgregarContenido([FromBody] API.Dto.Contenido.Entrada.AgregarContenido pDatos)
        {
            API.Dto.Contenido.Salida.AgregarContenido respuesta = new API.Dto.Contenido.Salida.AgregarContenido();
            try
            {
                respuesta = oLnContenido.AgregarContenido(pDatos);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("VerTodosContenidos")]
        public IActionResult VerTodosContenidos(API.Dto.Contenido.Entrada.VerTodosContenidos pDatos)
        {
            API.Dto.Contenido.Salida.VerTodosContenidos respuesta = new API.Dto.Contenido.Salida.VerTodosContenidos();



            try
            {
                respuesta = oLnContenido.VerTodosContenidos(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                //return Ok(respuesta);
            }
        }
        [HttpPost]
        [Route("EliminarContenido")]
        public IActionResult EliminarContenido([FromBody] API.Dto.Contenido.Entrada.EliminarContenido pDatos)
        {
            API.Dto.Contenido.Salida.EliminarContenido respuesta = new API.Dto.Contenido.Salida.EliminarContenido();



            try
            {
                respuesta = oLnContenido.EliminarContenido(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }




        [HttpPost]
        [Route("VerDetalleContenido")]
        public IActionResult VerDetalleContenido([FromBody] API.Dto.Contenido.Entrada.VerDetalleContenido pDatos)
        {
            API.Dto.Contenido.Salida.VerDetalleContenido respuesta = new API.Dto.Contenido.Salida.VerDetalleContenido();



            try
            {
                respuesta = oLnContenido.VerDetalleContenido(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }



        [HttpPost]
        [Route("EditarContenido")]
        public IActionResult EditarContenido([FromBody] API.Dto.Contenido.Entrada.EditarContenido pDatos)
        {
            API.Dto.Contenido.Salida.EditarContenido respuesta = new API.Dto.Contenido.Salida.EditarContenido();



            try
            {
                respuesta = oLnContenido.EditarContenido(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }
    }
}
