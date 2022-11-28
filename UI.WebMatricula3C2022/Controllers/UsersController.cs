using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using UI.WebMatricula3C2022.Models.Users;

namespace UI.WebMatricula3C2022.Controllers
{
    public class UsersController
    {
        public static string UrlBaseAuth { get; } = "http://localhost:4000/users/";
        public async Task<User> Authenticate(string username, string password)
        {
            AuthenticateModel authenticateModel = new AuthenticateModel()
            {
                Username = username,
                Password = password
            };

            HttpClient client = new HttpClient();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = client.PostAsync(string.Concat(UrlBaseAuth, "authenticate/"),
                new StringContent(
                    JsonConvert.SerializeObject(authenticateModel),
                    Encoding.UTF8, "application/json")).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<User>(
                await response.Content.ReadAsStringAsync());

        }
        public async Task<string> Register(RegisterModel model) { 
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response =await client.PostAsync(UrlBaseAuth+"register",new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json"));
            return await response.Content.ReadAsStringAsync();
        }
    }
}
