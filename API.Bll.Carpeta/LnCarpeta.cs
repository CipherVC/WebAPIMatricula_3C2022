using API.Bll.Carpeta.Interfaces;

namespace API.Bll.Carpeta
{
    public class LnCarpeta
    {
        private IAdCarpeta adCarpeta;



        public LnCarpeta(IAdCarpeta accesoDatosCarpeta)
        {
            this.adCarpeta = accesoDatosCarpeta;
        }



        public API.Dto.Carpeta.Salida.VerTodosCarpeta VerTodosCarpetas(Dto.Carpeta.Entrada.VerTodosCarpeta pInformacion)
        {
            API.Dto.Carpeta.Salida.VerTodosCarpeta respuesta = new API.Dto.Carpeta.Salida.VerTodosCarpeta();



            try
            {
                respuesta = adCarpeta.VerTodosCarpeta();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Carpeta.Salida.VerDetalleCarpeta VerDetalleCarpeta(Dto.Carpeta.Entrada.VerDetalleCarpeta pInformacion)
        {
            API.Dto.Carpeta.Salida.VerDetalleCarpeta respuesta = new Dto.Carpeta.Salida.VerDetalleCarpeta();



            try
            {
                respuesta = adCarpeta.VerDetalleCarpeta(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Carpeta.Salida.AgregarCarpeta AgregarCarpeta(Dto.Carpeta.Entrada.AgregarCarpeta pInformacion)
        {
            API.Dto.Carpeta.Salida.AgregarCarpeta respuesta = new API.Dto.Carpeta.Salida.AgregarCarpeta();



            try
            {
                respuesta = adCarpeta.AgregarCarpeta(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Carpeta.Salida.EditarCarpeta EditarCarpeta(Dto.Carpeta.Entrada.EditarCarpeta pInformacion)
        {
            API.Dto.Carpeta.Salida.EditarCarpeta respuesta = new API.Dto.Carpeta.Salida.EditarCarpeta();



            try
            {
                API.Dto.Carpeta.Entrada.VerDetalleCarpeta entradaVerDetalleCarpeta = new API.Dto.Carpeta.Entrada.VerDetalleCarpeta();
                entradaVerDetalleCarpeta.Codigo = pInformacion.Codigo;
                API.Dto.Carpeta.Salida.VerDetalleCarpeta detalleTrader = adCarpeta.VerDetalleCarpeta(entradaVerDetalleCarpeta);



                respuesta = adCarpeta.EditarCarpeta(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Carpeta.Salida.EliminarCarpeta EliminarCarpeta(Dto.Carpeta.Entrada.EliminarCarpeta pInformacion)
        {
            API.Dto.Carpeta.Salida.EliminarCarpeta respuesta = new Dto.Carpeta.Salida.EliminarCarpeta();



            try
            {
                respuesta = adCarpeta.EliminarCarpeta(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }
            return respuesta;
        }
    }
}