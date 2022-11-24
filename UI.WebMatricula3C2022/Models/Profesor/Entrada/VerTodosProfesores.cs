namespace UI.WebMatricula3C2022.Models.Profesor.Entrada
{
    public class VerTodosProfesores : General.EntradaAPI
    {
        public List<DatosProfesor> ListaProfesores { get; set; }



        public VerTodosProfesores()
        {
            ListaProfesores = new List<DatosProfesor>();
        }
    }



    public class DatosProfesor
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
