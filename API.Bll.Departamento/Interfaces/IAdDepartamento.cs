using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Departamento.Interfaces
{
    public interface IAdDepartamento
    {
        API.Dto.Departamento.Salida.VerTodosDepartamentos VerTodosDepartamentos();
        API.Dto.Departamento.Salida.VerDetalleDepartamento VerDetalleDepartamento(API.Dto.Departamento.Entrada.VerDetalleDepartamento pInformacion);
        API.Dto.Departamento.Salida.AgregarDepartamento AgregarDepartamento(API.Dto.Departamento.Entrada.AgregarDepartamento pInformacion);
        API.Dto.Departamento.Salida.EditarDepartamento EditarDepartamento(API.Dto.Departamento.Entrada.EditarDepartamento pInformacion);
        API.Dto.Departamento.Salida.EliminarDepartamento EliminarDepartamento(API.Dto.Departamento.Entrada.EliminarDepartamento pInformacion);
    }
}