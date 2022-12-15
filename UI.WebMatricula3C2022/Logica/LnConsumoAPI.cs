using Newtonsoft.Json;
using System.Text;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnConsumoAPI
    {
        public async Task<string> ConsumirAPI(string oEncabezado, string oCuerpo, string token) {
            string oServidor = "https://localhost:7269/api/v1/";

            string oUrlServicio = string.Concat(oServidor, oEncabezado);
            try
            {
                HttpClient httpClient = new HttpClient();
                
                if (!string.IsNullOrEmpty(token)) {
                    httpClient.DefaultRequestHeaders.Add("Authorization", string.Concat("Bearer ", token));
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                }
                var respuestaServicio= await httpClient.PostAsync(oUrlServicio, new StringContent(oCuerpo, Encoding.UTF8,"application/json"));
                var result=await respuestaServicio.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
