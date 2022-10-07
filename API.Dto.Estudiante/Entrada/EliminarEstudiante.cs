using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Estudiante.Entrada
{
    public class EliminarEstudiante : General.EntradaAPI
    {
        public int Codigo { get; set; }
    }
}
