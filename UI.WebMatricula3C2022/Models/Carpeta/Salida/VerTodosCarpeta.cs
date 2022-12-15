﻿
namespace UI.WebMatricula3C2022.Models.Carpeta.Salida
{
    public class VerTodosCarpeta:General.RespuestaAPI
    {
        public List<DatosCarpeta> ListaCarpeta { get; set; }

        public VerTodosCarpeta() {
            ListaCarpeta = new List<DatosCarpeta>();
        }

    }
    public class DatosCarpeta {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string VisibleEstudiantes { get; set; }
        public int CodigoCurso { get; set; }
    }
}