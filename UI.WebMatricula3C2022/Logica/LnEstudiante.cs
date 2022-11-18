using Newtonsoft.Json;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnEstudiante
    {
        LnConsumoAPI lnConsumoAPI = new LnConsumoAPI();


        public async Task<Models.Estudiante.Salida.VerTodosEstudiantes> VerTodosEstudiantes(Models.Estudiante.Entrada.VerTodosEstudiantes oInsumos,string token) {
            string encabezado = "Estudiante/VerTodosEstudiantes";
            string cuerpo = JsonConvert.SerializeObject(oInsumos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.VerTodosEstudiantes>(respuesta);
        }
        public async Task<Models.Estudiante.Salida.AgregarEstudiante> AgregarEstudiante(Models.Estudiante.Entrada.AgregarEstudiante pDatos, string token) {
            string encabezado = "Estudiante/AgregarEstudiante";
            string cuerpo=JsonConvert.SerializeObject(pDatos);
            string respuesta=await lnConsumoAPI.ConsumirAPI(encabezado,cuerpo,token);
            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.AgregarEstudiante>(respuesta);
        
        }
        public async Task<Models.Estudiante.Salida.EditarEstudiante> EditarEstudiante(Models.Estudiante.Entrada.EditarEstudiante pDatos, string token)
        {
            string encabezado = "Estudiante/EditarEstudiante";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.EditarEstudiante>(respuesta);

        }
        public async Task<Models.Estudiante.Salida.EliminarEstudiante> EliminarEstudiante(Models.Estudiante.Entrada.EliminarEstudiante pDatos, string token)
        {
            string encabezado = "Estudiante/EliminarEstudiante";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.EliminarEstudiante>(respuesta);

        }
        public async Task<Models.Estudiante.Salida.VerDetalleEstudiante> VerDetalleEstudiante(Models.Estudiante.Entrada.VerDetalleEstudiante pDatos, string token)
        {
            string encabezado = "Estudiante/VerDetalleEstudiantes";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.VerDetalleEstudiante>(respuesta);

        }

    }
}
