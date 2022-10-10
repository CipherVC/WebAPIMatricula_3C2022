using API.Bll.Error.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Error
{
    public class LnError
    {
        private IAdError adError;

        public LnError(IAdError accesoDatosError)
        {
            this.adError = accesoDatosError;
        }
        //random
        public API.Dto.Error.Salida.AgregarError AgregarError(Dto.Error.Entrada.AgregarError pInformacion)
        {
            API.Dto.Error.Salida.AgregarError respuesta = new API.Dto.Error.Salida.AgregarError();

            try
            {
                respuesta = adError.AgregarError(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public API.Dto.Error.Salida.VerTodosErrores VerTodosErrores(Dto.Error.Entrada.VerTodosErrores pInformacion)
        {
            API.Dto.Error.Salida.VerTodosErrores respuesta = new API.Dto.Error.Salida.VerTodosErrores();

            try
            {
                respuesta = adError.VerTodosErrores();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
