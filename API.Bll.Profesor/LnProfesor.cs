using API.Bll.Profesor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Profesor
{
    public class LnProfesor
    {
        private IAdProfesor adProfesor;



        public LnProfesor(IAdProfesor accesoDatosProfesor)
        {
            this.adProfesor = accesoDatosProfesor;
        }



        public API.Dto.Profesor.Salida.VerTodosProfesores VerTodosProfesores(Dto.Profesor.Entrada.VerTodosProfesores pInformacion)
        {
            API.Dto.Profesor.Salida.VerTodosProfesores respuesta = new API.Dto.Profesor.Salida.VerTodosProfesores();



            try
            {
                respuesta = adProfesor.VerTodosProfesores();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Profesor.Salida.VerDetalleProfesor VerDetalleProfesor(Dto.Profesor.Entrada.VerDetalleProfesor pInformacion)
        {
            API.Dto.Profesor.Salida.VerDetalleProfesor respuesta = new Dto.Profesor.Salida.VerDetalleProfesor();



            try
            {
                respuesta = adProfesor.VerDetalleProfesor(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Profesor.Salida.AgregarProfesor AgregarProfesor(Dto.Profesor.Entrada.AgregarProfesor pInformacion)
        {
            API.Dto.Profesor.Salida.AgregarProfesor respuesta = new API.Dto.Profesor.Salida.AgregarProfesor();



            try
            {
                respuesta = adProfesor.AgregarProfesor(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Profesor.Salida.EditarProfesor EditarProfesor(Dto.Profesor.Entrada.EditarProfesor pInformacion)
        {
            API.Dto.Profesor.Salida.EditarProfesor respuesta = new API.Dto.Profesor.Salida.EditarProfesor();



            try
            {
                API.Dto.Profesor.Entrada.VerDetalleProfesor entradaVerDetalleProfesor = new API.Dto.Profesor.Entrada.VerDetalleProfesor();
                entradaVerDetalleProfesor.Codigo = pInformacion.Codigo;
                API.Dto.Profesor.Salida.VerDetalleProfesor detalleTrader = adProfesor.VerDetalleProfesor(entradaVerDetalleProfesor);



                respuesta = adProfesor.EditarProfesor(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Profesor.Salida.EliminarProfesor EliminarProfesor(Dto.Profesor.Entrada.EliminarProfesor pInformacion)
        {
            API.Dto.Profesor.Salida.EliminarProfesor respuesta = new Dto.Profesor.Salida.EliminarProfesor();



            try
            {
                respuesta = adProfesor.EliminarProfesor(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
    }
}