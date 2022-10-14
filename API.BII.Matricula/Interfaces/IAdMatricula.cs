using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Matricula.Interfaces
{
    public interface IAdMatricula
    {
        API.Dto.Matricula.Salida.VerTodasMatriculas VerTodasMatriculas();
        API.Dto.Matricula.Salida.VerDetalleMatricula VerDetalleMatricula(API.Dto.Matricula.Entrada.VerDetalleMatricula pInformacion);
        API.Dto.Matricula.Salida.AgregarMatricula AgregarMatricula(API.Dto.Matricula.Entrada.AgregarMatricula pInformacion);
        API.Dto.Matricula.Salida.EditarMatricula EditarMatricula(API.Dto.Matricula.Entrada.EditarMatricula pInformacion);
        API.Dto.Matricula.Salida.EliminarMatricula EliminarMatricula(API.Dto.Matricula.Entrada.EliminarMatricula pInformacion);
    }
}
