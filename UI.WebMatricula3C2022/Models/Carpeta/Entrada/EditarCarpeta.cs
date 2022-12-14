
namespace UI.WebMatricula3C2022.Models.Carpeta.Entrada
{
    public class EditarCarpeta:General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string VisibleEstudiantes { get; set; }
        public int CodigoCurso { get; set; }
    }
}
