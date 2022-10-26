using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Contenido.Interfaces
{
    public class IAdContenido
    {
        public API.Dto.Contenido.Salida.VerTodosContenidos VerTodosContenido();
        public API.Dto.Contenido.Salida.VerDetalleContenido VerDetalleContenido(API.Dto.Contenido.Entrada.VerDetalleContenido pInformacion);
        public API.Dto.Contenido.Salida.AgregarContenido AgregarContenido(API.Dto.Contenido.Entrada.AgregarContenido pInformacion);
        public API.Dto.Contenido.Salida.EditarContenido EditarContenido(API.Dto.Contenido.Entrada.EditarContenido pInformacion);
        public API.Dto.Contenido.Salida.EliminarContenido EliminarContenido(API.Dto.Contenido.Entrada.EliminarContenido pInformacion);
    }
}
