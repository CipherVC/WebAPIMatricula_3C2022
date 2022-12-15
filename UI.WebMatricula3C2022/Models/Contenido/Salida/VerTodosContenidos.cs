
namespace UI.WebMatricula3C2022.Models.Contenido.Salida
{
    public class VerTodosContenidos:General.RespuestaAPI
    {
        public List<DatosContenido> ListaContenido { get; set; }



        public VerTodosContenidos()
        {
            ListaContenido = new List<DatosContenido>();
        }
    }
    public class DatosContenido{
        public int Codigo { get; set; }
        public string NombreArchivo { get; set; }
        public string Contenido { get; set; }
        public int CodigoCarpeta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
