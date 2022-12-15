using API.Bll.Contenido.Interfaces;

namespace API.Bll.Contenido
{
    public class LnContenido
    {
        private IAdContenido adContenido;
        public LnContenido(IAdContenido accesoDatosContenido)
        {
            this.adContenido = accesoDatosContenido;
        }



        public API.Dto.Contenido.Salida.VerTodosContenidos VerTodosContenidos(Dto.Contenido.Entrada.VerTodosContenidos pInformacion)
        {
            API.Dto.Contenido.Salida.VerTodosContenidos respuesta = new API.Dto.Contenido.Salida.VerTodosContenidos();



            try
            {
                respuesta = adContenido.VerTodosContenido();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Contenido.Salida.VerDetalleContenido VerDetalleContenido(Dto.Contenido.Entrada.VerDetalleContenido pInformacion)
        {
            API.Dto.Contenido.Salida.VerDetalleContenido respuesta = new Dto.Contenido.Salida.VerDetalleContenido();



            try
            {
                respuesta = adContenido.VerDetalleContenido(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Contenido.Salida.AgregarContenido AgregarContenido(Dto.Contenido.Entrada.AgregarContenido pInformacion)
        {
            API.Dto.Contenido.Salida.AgregarContenido respuesta = new API.Dto.Contenido.Salida.AgregarContenido();



            try
            {
                respuesta = adContenido.AgregarContenido(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Contenido.Salida.EditarContenido EditarContenido(Dto.Contenido.Entrada.EditarContenido pInformacion)
        {
            API.Dto.Contenido.Salida.EditarContenido respuesta = new API.Dto.Contenido.Salida.EditarContenido();



            try
            {
                API.Dto.Contenido.Entrada.VerDetalleContenido entradaVerDetalleContenido = new API.Dto.Contenido.Entrada.VerDetalleContenido();
                entradaVerDetalleContenido.Codigo = pInformacion.Codigo;
                API.Dto.Contenido.Salida.VerDetalleContenido detalleTrader = adContenido.VerDetalleContenido(entradaVerDetalleContenido);



                respuesta = adContenido.EditarContenido(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Contenido.Salida.EliminarContenido EliminarContenido(Dto.Contenido.Entrada.EliminarContenido pInformacion)
        {
            API.Dto.Contenido.Salida.EliminarContenido respuesta = new Dto.Contenido.Salida.EliminarContenido();



            try
            {
                respuesta = adContenido.EliminarContenido(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
    }
}