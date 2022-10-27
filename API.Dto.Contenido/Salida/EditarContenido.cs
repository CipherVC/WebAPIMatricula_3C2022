using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Contenido.Salida
{
    public class EditarContenido:General.RespuestaAPI
    {    
        public int Codigo { get; set; }
        public string NombreArchivo { get; set; }
        public string Ruta { get; set; }
        public int CodigoCarpeta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
