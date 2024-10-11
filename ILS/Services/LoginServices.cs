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

        public async Task<HttpResponseMessage> CreateClientAsync(string authToken, string clientId, string clientName, string email, string contactNo)
        {
            // Set authorization header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

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

            return await httpClient.PostAsync("https://dev-api.ils-provision.co.uk/api/v1/lawyer/client/create", jsonContent);
        }
        public async Task<HttpResponseMessage> CreateMatterAsync(string authToken, int clientId, string matterName, string matterId, string currency, string[] jurisdiction, string matterType)
        {
            // Set authorization header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    matter_name = matterName,
                    matter_id = matterId,
                    client = clientId, // Pass the client ID here
                    currency = currency,
                    jurisdiction = jurisdiction,
                    matter_type = matterType
                }),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PostAsync("https://dev-api.ils-provision.co.uk/api/v1/lawyer/matter/create", jsonContent);
        }

    }
}
