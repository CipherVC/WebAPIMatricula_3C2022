using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Profesor.Entrada
{
    public class VerTodosProfesores : Dto.General.RespuestaAPI
    {
        public List<DatosProfesor> ListaProfesores { get; set; }



        public VerTodosProfesores()
        {
            ListaProfesores = new List<DatosProfesor>();
        }
    }



    public class DatosProfesor
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
