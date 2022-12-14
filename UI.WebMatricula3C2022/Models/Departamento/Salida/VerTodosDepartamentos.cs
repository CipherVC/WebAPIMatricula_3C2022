namespace UI.WebMatricula3C2022.Models.Departamento.Salida
{
    public class VerTodosDepartamentos : General.RespuestaAPI
    {
        public List<DatosDepartamento> ListaDepartamentos { get; set; }



        public VerTodosDepartamentos()
        {
            ListaDepartamentos = new List<DatosDepartamento>();
        }
    }



    public class DatosDepartamento
    {
        public int Codigo { get; set; }
        public string NombreDepartamento { get; set; }
        public string DescripcionDepartamento { get; set; }
        public string DirectorDepartamento { get; set; }
        public string Telefono { get; set; }
    }
}
