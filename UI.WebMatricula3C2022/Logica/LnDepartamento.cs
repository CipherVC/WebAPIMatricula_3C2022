using Newtonsoft.Json;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnDepartamento
    {
        LnConsumoAPI lnConsumoAPI = new LnConsumoAPI();


        public async Task<Models.Departamento.Salida.VerTodosDepartamentos> VerTodosDepartamentos(Models.Departamento.Entrada.VerTodosDepartamentos oInsumos, string token)
        {
            string encabezado = "Departamento/VerTodosDepartamentos";
            string cuerpo = JsonConvert.SerializeObject(oInsumos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Departamento.Salida.VerTodosDepartamentos>(respuesta);
        }
        public async Task<Models.Departamento.Salida.AgregarDepartamento> AgregarDepartamento(Models.Departamento.Entrada.AgregarDepartamento pDatos, string token)
        {
            string encabezado = "Departamento/AgregarDepartamento";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Departamento.Salida.AgregarDepartamento>(respuesta);

        }
        public async Task<Models.Departamento.Salida.EditarDepartamento> EditarDepartamento(Models.Departamento.Entrada.EditarDepartamento pDatos, string token)
        {
            string encabezado = "Departamento/EditarDepartamento";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Departamento.Salida.EditarDepartamento>(respuesta);

        }
        public async Task<Models.Departamento.Salida.EliminarDepartamento> EliminarDepartamento(Models.Departamento.Entrada.EliminarDepartamento pDatos, string token)
        {
            string encabezado = "Departamento/EliminarDepartamento";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Departamento.Salida.EliminarDepartamento>(respuesta);

        }
        public async Task<Models.Departamento.Salida.VerDetalleDepartamento> VerDetalleDepartamento(Models.Departamento.Entrada.VerDetalleDepartamento pDatos, string token)
        {
            string encabezado = "Departamento/VerDetalleDepartamento";
            string cuerpo = JsonConvert.SerializeObject(pDatos);
            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);
            return JsonConvert.DeserializeObject<Models.Departamento.Salida.VerDetalleDepartamento>(respuesta);

        }

    }
}
