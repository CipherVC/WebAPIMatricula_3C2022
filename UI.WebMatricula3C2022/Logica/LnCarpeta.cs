using Newtonsoft.Json;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnCarpeta
    {

        LnConsumoAPI lnConsumoAPI = new LnConsumoAPI();


        public async Task<Models.Carpeta.Salida.VerTodosCarpeta> VerTodosCarpetas(Models.Carpeta.Entrada.VerTodosCarpeta oInsumos, string token)
        {
            string encabezado = "Carpeta/VerTodosCarpetas";
            string cuerpo = JsonConvert.SerializeObject(oInsumos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Carpeta.Salida.VerTodosCarpeta>(respuesta);
        }
        public async Task<Models.Carpeta.Salida.AgregarCarpeta> AgregarCarpeta(Models.Carpeta.Entrada.AgregarCarpeta pDatos, string token)
        {
            string encabezado = "Carpeta/AgregarCarpeta";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Carpeta.Salida.AgregarCarpeta>(respuesta);

        }
        public async Task<Models.Carpeta.Salida.EditarCarpeta> EditarCarpeta(Models.Carpeta.Entrada.EditarCarpeta pDatos, string token)
        {
            string encabezado = "Carpeta/EditarCarpeta";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Carpeta.Salida.EditarCarpeta>(respuesta);

        }
        public async Task<Models.Carpeta.Salida.EliminarCarpeta> EliminarCarpeta(Models.Carpeta.Entrada.EliminarCarpeta pDatos, string token)
        {
            string encabezado = "Carpeta/EliminarCarpeta";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Carpeta.Salida.EliminarCarpeta>(respuesta);

        }
        public async Task<Models.Carpeta.Salida.VerDetalleCarpeta> VerDetalleCarpeta(Models.Carpeta.Entrada.VerDetalleCarpeta pDatos, string token)
        {
            string encabezado = "Carpeta/VerDetalleCarpeta";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Carpeta.Salida.VerDetalleCarpeta>(respuesta);

        }
    }
}
