using System.Net.Http;
using System.Text;
using Aggregator.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aggregator.Controllers
{
    public class BaseAggregatorController : ControllerBase
    {
        protected string _recipeHubBaseUrl => "https://ne-recipehub-intern.azurewebsites.net/api/";
        protected static HttpClient _httpClient = new HttpClient();
        protected void LogIn()
        {
            var json = new LogIn
            {
                Username = "djuka6",
                Password = "Nekipass12345/"
            };
            using (var content = new StringContent(JsonConvert.SerializeObject(json), System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = _httpClient.PostAsync("https://ne-authapp-intern.azurewebsites.net/api/users/authenticate", content).Result;
                string returnValue = result.Content.ReadAsStringAsync().Result;
                LogInResponse? response = System.Text.Json.JsonSerializer.Deserialize<LogInResponse>(returnValue);
                _httpClient.DefaultRequestHeaders.Add("token", response.token);
            }
        }
        protected StringContent GetContent(object content)
        {
            return new StringContent(JsonConvert.SerializeObject(content, settings: new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            }), Encoding.UTF8, "application/json");
        }

    }
}
