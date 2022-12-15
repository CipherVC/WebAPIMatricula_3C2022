namespace UI.WebMatricula3C2022.Models.Departamento.Salida
{
    public class VerDetalleDepartamento : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string NombreDepartamento { get; set; }
        public string DescripcionDepartamento { get; set; }
        public string DirectorDepartamento { get; set; }
        public string Telefono { get; set; }
    }
}
