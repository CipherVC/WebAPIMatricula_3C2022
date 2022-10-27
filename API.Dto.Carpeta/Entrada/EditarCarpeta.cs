using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Carpeta.Entrada
{
    internal class EditarCarpeta:General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string VisibleEstudiantes { get; set; }
        public int CodigoCurso { get; set; }
    }
}
