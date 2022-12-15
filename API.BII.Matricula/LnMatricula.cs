using API.Bll.Matricula.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Bll.Matricula
{
    public class LnMatricula
    {
        private IAdMatricula adMatricula;



        public LnMatricula(IAdMatricula accesoDatosMatricula)
        {
            this.adMatricula = accesoDatosMatricula;
        }



        public API.Dto.Matricula.Salida.VerTodasMatriculas VerTodasMatriculas(Dto.Matricula.Entrada.VerTodasMatriculas pInformacion)
        {
            API.Dto.Matricula.Salida.VerTodasMatriculas respuesta = new API.Dto.Matricula.Salida.VerTodasMatriculas();



            try
            {
                respuesta = adMatricula.VerTodasMatriculas();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Matricula.Salida.VerDetalleMatricula VerDetalleMatricula(Dto.Matricula.Entrada.VerDetalleMatricula pInformacion)
        {
            API.Dto.Matricula.Salida.VerDetalleMatricula respuesta = new Dto.Matricula.Salida.VerDetalleMatricula();



            try
            {
                respuesta = adMatricula.VerDetalleMatricula(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Matricula.Salida.AgregarMatricula AgregarMatricula(Dto.Matricula.Entrada.AgregarMatricula pInformacion)
        {
            API.Dto.Matricula.Salida.AgregarMatricula respuesta = new API.Dto.Matricula.Salida.AgregarMatricula();



            try
            {
                respuesta = adMatricula.AgregarMatricula(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Matricula.Salida.EditarMatricula EditarMatricula(Dto.Matricula.Entrada.EditarMatricula pInformacion)
        {
            API.Dto.Matricula.Salida.EditarMatricula respuesta = new API.Dto.Matricula.Salida.EditarMatricula();



            try
            {
                API.Dto.Matricula.Entrada.VerDetalleMatricula entradaVerDetalleMatricula = new API.Dto.Matricula.Entrada.VerDetalleMatricula();
                entradaVerDetalleMatricula.Codigo = pInformacion.Codigo;
                API.Dto.Matricula.Salida.VerDetalleMatricula detalleTrader = adMatricula.VerDetalleMatricula(entradaVerDetalleMatricula);



                respuesta = adMatricula.EditarMatricula(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Matricula.Salida.EliminarMatricula EliminarMatricula(Dto.Matricula.Entrada.EliminarMatricula pInformacion)
        {
            API.Dto.Matricula.Salida.EliminarMatricula respuesta = new Dto.Matricula.Salida.EliminarMatricula();



            try
            {
                respuesta = adMatricula.EliminarMatricula(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
    }
}