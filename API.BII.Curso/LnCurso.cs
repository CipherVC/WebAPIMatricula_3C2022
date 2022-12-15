using API.Bll.Curso.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Bll.Curso
{
    public class LnCurso
    {
        private IAdCurso adCurso;



        public LnCurso(IAdCurso accesoDatosCurso)
        {
            this.adCurso = accesoDatosCurso;
        }



        public API.Dto.Curso.Salida.VerTodosCursos VerTodosCursos(Dto.Curso.Entrada.VerTodosCursos pInformacion)
        {
            API.Dto.Curso.Salida.VerTodosCursos respuesta = new API.Dto.Curso.Salida.VerTodosCursos();



            try
            {
                respuesta = adCurso.VerTodosCursos();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Curso.Salida.VerDetalleCurso VerDetalleCurso(Dto.Curso.Entrada.VerDetalleCurso pInformacion)
        {
            API.Dto.Curso.Salida.VerDetalleCurso respuesta = new Dto.Curso.Salida.VerDetalleCurso();



            try
            {
                respuesta = adCurso.VerDetalleCurso(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Curso.Salida.AgregarCurso AgregarCurso(Dto.Curso.Entrada.AgregarCurso pInformacion)
        {
            API.Dto.Curso.Salida.AgregarCurso respuesta = new API.Dto.Curso.Salida.AgregarCurso();



            try
            {
                respuesta = adCurso.AgregarCurso(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Curso.Salida.EditarCurso EditarCurso(Dto.Curso.Entrada.EditarCurso pInformacion)
        {
            API.Dto.Curso.Salida.EditarCurso respuesta = new API.Dto.Curso.Salida.EditarCurso();



            try
            {
                API.Dto.Curso.Entrada.VerDetalleCurso entradaVerDetalleCurso = new API.Dto.Curso.Entrada.VerDetalleCurso();
                entradaVerDetalleCurso.Codigo = pInformacion.Codigo;
                API.Dto.Curso.Salida.VerDetalleCurso detalleTrader = adCurso.VerDetalleCurso(entradaVerDetalleCurso);



                respuesta = adCurso.EditarCurso(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Curso.Salida.EliminarCurso EliminarCurso(Dto.Curso.Entrada.EliminarCurso pInformacion)
        {
            API.Dto.Curso.Salida.EliminarCurso respuesta = new Dto.Curso.Salida.EliminarCurso();



            try
            {
                respuesta = adCurso.EliminarCurso(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
    }
}