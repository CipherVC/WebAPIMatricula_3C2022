using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Profesor.Interfaces
{
    public interface IAdProfesor
    {
        API.Dto.Profesor.Salida.VerTodosProfesores VerTodosProfesores();
        API.Dto.Profesor.Salida.VerDetalleProfesor VerDetalleProfesor(API.Dto.Profesor.Entrada.VerDetalleProfesor pInformacion);
        API.Dto.Profesor.Salida.AgregarProfesor AgregarProfesor(API.Dto.Profesor.Entrada.AgregarProfesor pInformacion);
        API.Dto.Profesor.Salida.EditarProfesor EditarProfesor(API.Dto.Profesor.Entrada.EditarProfesor pInformacion);
        API.Dto.Profesor.Salida.EliminarProfesor EliminarProfesor(API.Dto.Profesor.Entrada.EliminarProfesor pInformacion);
    }
}