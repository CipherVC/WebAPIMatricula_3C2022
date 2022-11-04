namespace UI.WebMatricula3C2022.Models.Estudiante.Salida
{
    public class VerTodosEstudiantes:General.RespuestaAPI
    {
        public List<DatosEstudiante> ListaEstudiantes = new List<DatosEstudiante>();
        public VerTodosEstudiantes()
        {
            ListaEstudiantes = new List<DatosEstudiante>();
        }
    }
    public class DatosEstudiante
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Estado { get; set; }
    }

 
}
