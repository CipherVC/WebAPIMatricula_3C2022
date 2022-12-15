namespace UI.WebMatricula3C2022.Models.Departamento.Entrada
{
    public class VerTodosDepartamentos : General.EntradaAPI
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
        public string DescricionDepartamento { get; set; }
        public string DirectorDepartamento { get; set; }
        public string Telefono { get; set; }
    }
}

