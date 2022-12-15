
namespace UI.WebMatricula3C2022.Models.Carpeta.Entrada

{
    public class AgregarCarpeta:General.EntradaAPI
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string VisibleEstudiantes { get; set; }
        public int CodigoCurso { get; set; }
    }
}
