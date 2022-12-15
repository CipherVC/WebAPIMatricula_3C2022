using Newtonsoft.Json;
namespace UI.WebMatricula3C2022.Logica
{
    public class LnContenido
    {
        LnConsumoAPI lnConsumoAPI = new LnConsumoAPI();


        public async Task<Models.Contenido.Salida.VerTodosContenidos> VerTodosContenidos(Models.Contenido.Entrada.VerTodosContenidos oInsumos, string token)
        {
            string encabezado = "Contenido/VerTodosContenidos";
            string cuerpo = JsonConvert.SerializeObject(oInsumos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Contenido.Salida.VerTodosContenidos>(respuesta);
        }
        public async Task<Models.Contenido.Salida.AgregarContenido> AgregarContenido(Models.Contenido.Entrada.AgregarContenido pDatos, string token)
        {
            string encabezado = "Contenido/AgregarContenido";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Contenido.Salida.AgregarContenido>(respuesta);

        }
        public async Task<Models.Contenido.Salida.EditarContenido> EditarContenido(Models.Contenido.Entrada.EditarContenido pDatos, string token)
        {
            string encabezado = "Contenido/EditarContenido";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Contenido.Salida.EditarContenido>(respuesta);

        }
        public async Task<Models.Contenido.Salida.EliminarContenido> EliminarContenido(Models.Contenido.Entrada.EliminarContenido pDatos, string token)
        {
            string encabezado = "Contenido/EliminarContenido";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Contenido.Salida.EliminarContenido>(respuesta);

        }
        public async Task<Models.Contenido.Salida.VerDetalleContenido> VerDetalleContenido(Models.Contenido.Entrada.VerDetalleContenido pDatos, string token)
        {
            string encabezado = "Contenido/VerDetalleContenido";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Contenido.Salida.VerDetalleContenido>(respuesta);

        }
    }
}
