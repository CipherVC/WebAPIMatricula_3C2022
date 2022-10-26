using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Contenido.Entrada
{
    public class AgregarContenido:General.EntradaAPI
    {
        public string NombreArchivo { get; set; }
        public string Ruta { get; set; }
        public string CodigoCarpeta { get; set; }
        public DateTime FechaCreacion { get; set;  }
    }
}
