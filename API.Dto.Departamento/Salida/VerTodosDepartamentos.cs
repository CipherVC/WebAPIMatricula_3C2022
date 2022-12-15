using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Departamento.Salida
{
    public class VerTodosDepartamentos : Dto.General.RespuestaAPI
    {
        public List<DatosDepartamento> ListaDepartamentos { get; set; }



        public VerTodosDepartamentos()
        {
            ListaDepartamentos = new List<DatosDepartamento>();
        }
    }



    public class DatosDepartamento
    {
        public int Codigo { get; set; }
        public string NombreDepartamento { get; set; }
        public string DescripcionDepartamento { get; set; }
        public string DirectorDepartamento { get; set; }
        public string Telefono { get; set; }
    }
}
