using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Contenido.Interfaces
{
    public interface IAdContenido
    {
         API.Dto.Contenido.Salida.VerTodosContenidos VerTodosContenido();
         API.Dto.Contenido.Salida.VerDetalleContenido VerDetalleContenido(API.Dto.Contenido.Entrada.VerDetalleContenido pInformacion);
         API.Dto.Contenido.Salida.AgregarContenido AgregarContenido(API.Dto.Contenido.Entrada.AgregarContenido pInformacion);
        API.Dto.Contenido.Salida.EditarContenido EditarContenido(API.Dto.Contenido.Entrada.EditarContenido pInformacion);
         API.Dto.Contenido.Salida.EliminarContenido EliminarContenido(API.Dto.Contenido.Entrada.EliminarContenido pInformacion);
    }
}
