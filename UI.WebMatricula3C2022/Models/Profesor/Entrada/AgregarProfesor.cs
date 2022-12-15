namespace UI.WebMatricula3C2022.Models.Profesor.Entrada
{
    public class AgregarProfesor : General.EntradaAPI
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
