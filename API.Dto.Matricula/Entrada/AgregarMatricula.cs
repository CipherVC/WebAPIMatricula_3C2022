using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Matricula.Entrada
{
    public class AgregarMatricula : General.EntradaAPI
    {
        public int CodigoUsuario { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoEstudiante { get; set; }
        public DateTime FechaHora { get; set; }

    }
}
