using API.Bll.Carpeta;
using API.Bll.Carpeta.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_3C2022.Controllers
{
    [Route("api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    public class CarpetaController : Controller
    {

        private LnCarpeta oLnCarpeta;
        public CarpetaController(IAdCarpeta accesoAdCarpeta)
        {
            oLnCarpeta = new LnCarpeta(accesoAdCarpeta);

        }
        [HttpPost]
        [Route("AgregarCarpeta")]
        public IActionResult AgregarCarpeta([FromBody] API.Dto.Carpeta.Entrada.AgregarCarpeta pDatos)
        {
            API.Dto.Carpeta.Salida.AgregarCarpeta respuesta = new API.Dto.Carpeta.Salida.AgregarCarpeta();
            try
            {
                respuesta = oLnCarpeta.AgregarCarpeta(pDatos);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("VerTodosCarpetas")]
        public IActionResult VerTodosCarpetas(API.Dto.Carpeta.Entrada.VerTodosCarpeta pDatos)
        {
            API.Dto.Carpeta.Salida.VerTodosCarpeta respuesta = new API.Dto.Carpeta.Salida.VerTodosCarpeta();



            try
            {
                respuesta = oLnCarpeta.VerTodosCarpetas(pDatos);
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
        [Route("EliminarCarpeta")]
        public IActionResult EliminarCarpeta([FromBody] API.Dto.Carpeta.Entrada.EliminarCarpeta pDatos)
        {
            API.Dto.Carpeta.Salida.EliminarCarpeta respuesta = new API.Dto.Carpeta.Salida.EliminarCarpeta();



            try
            {
                respuesta = oLnCarpeta.EliminarCarpeta(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }




        [HttpPost]
        [Route("VerDetalleCarpeta")]
        public IActionResult VerDetalleCarpeta([FromBody] API.Dto.Carpeta.Entrada.VerDetalleCarpeta pDatos)
        {
            API.Dto.Carpeta.Salida.VerDetalleCarpeta respuesta = new API.Dto.Carpeta.Salida.VerDetalleCarpeta();



            try
            {
                respuesta = oLnCarpeta.VerDetalleCarpeta(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }



        [HttpPost]
        [Route("EditarCarpeta")]
        public IActionResult EditarCarpeta([FromBody] API.Dto.Carpeta.Entrada.EditarCarpeta pDatos)
        {
            API.Dto.Carpeta.Salida.EditarCarpeta respuesta = new API.Dto.Carpeta.Salida.EditarCarpeta();



            try
            {
                respuesta = oLnCarpeta.EditarCarpeta(pDatos);
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
