
namespace UI.WebMatricula3C2022.Models.Contenido.Entrada
{
    public class EditarContenido:General.EntradaAPI
    {    
        public int Codigo { get; set; }
        public string NombreArchivo { get; set; }
        public string Contenido { get; set; }
        public int CodigoCarpeta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
