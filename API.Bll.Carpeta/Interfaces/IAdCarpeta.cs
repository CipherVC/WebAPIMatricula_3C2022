using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Carpeta.Interfaces
{
    public interface IAdCarpeta
    {
        public API.Dto.Carpeta.Salida.VerTodosCarpeta VerTodosCarpeta();
        public API.Dto.Carpeta.Salida.VerDetalleCarpeta VerDetalleCarpeta(API.Dto.Carpeta.Entrada.VerDetalleCarpeta pInformacion);
        public API.Dto.Carpeta.Salida.AgregarCarpeta AgregarCarpeta(API.Dto.Carpeta.Entrada.AgregarCarpeta pInformacion);
        public API.Dto.Carpeta.Salida.EditarCarpeta EditarCarpeta(API.Dto.Carpeta.Entrada.EditarCarpeta pInformacion);
        public API.Dto.Carpeta.Salida.EliminarCarpeta EliminarCarpeta(API.Dto.Carpeta.Entrada.EliminarCarpeta pInformacion);
    }
}
