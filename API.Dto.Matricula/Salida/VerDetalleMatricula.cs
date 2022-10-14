using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Matricula.Salida
{
    public class VerDetalleMatricula : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoEstudiante { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
