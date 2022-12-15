namespace UI.WebMatricula3C2022.Models.Departamento.Entrada
{
    public class EditarDepartamento : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string NombreDepartamento { get; set; }
        public string DescripcionDepartamento { get; set; }
        public string DirectorDepartamento { get; set; }
        public string Telefono { get; set; }
    }
}
