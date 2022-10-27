using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Departamento.Entrada
{
    public class AgregarDepartamento : General.EntradaAPI
    {
        public string NombreDepartamento { get; set; }
        public string DescripcionDepartamento { get; set; }
        public string DirectorDepartamento { get; set; }
        public string Telefono { get; set; }
       

    }
}
