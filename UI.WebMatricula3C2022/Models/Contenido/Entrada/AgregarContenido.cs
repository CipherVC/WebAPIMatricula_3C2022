
namespace UI.WebMatricula3C2022.Models.Contenido.Entrada
{
    public class AgregarContenido: General.EntradaAPI
    {
        public string NombreArchivo { get; set; }
        public string Contenido { get; set; }
        public int CodigoCarpeta { get; set; }
        public DateTime FechaCreacion { get; set;  }
    }
}
