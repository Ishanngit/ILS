using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ILS.Services
{
    public class ClientService
    {
        private readonly HttpClient httpClient;

        public ClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateClientAsync(string token, string clientId, string clientName, string email, string contactNo)
        {
            // Set authorization header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Create your JSON payload here
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    client_id = clientId,
                    client_name = clientName,
                    client_type = "firm-wide",
                    email = email,
                    contact_no = contactNo
                }),
                Encoding.UTF8,
                "application/json");

            // Make the POST request
            return await httpClient.PostAsync("https://dev-api.ils-provision.co.uk/api/v1/lawyer/client/create", jsonContent);
        }
    }
}
