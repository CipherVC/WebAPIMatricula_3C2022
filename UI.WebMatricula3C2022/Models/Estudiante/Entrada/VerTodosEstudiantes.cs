namespace UI.WebMatricula3C2022.Models.Estudiante.Entrada
{
    public class VerTodosEstudiantes:General.EntradaAPI
    {
        public List<DatosEstudiante> ListaEstudiantes { get; set; }



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
