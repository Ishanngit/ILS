using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using ILS.Services;
using ILS.Utilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ILS.StepDefination
{
    [Binding]
    public class WithAPIPRocessStepDefinitions : BaseClass
    {
        private int clientId;
        private int matterId;
        public WithAPIPRocessStepDefinitions() : base() { }

        [When(@"the system create Client data through API")]
        public async Task WhenTheSystemCreateClientDataThroughAPI()
        {
            var token = GetAuthToken(); // Retrieve the token from BaseClass

            if (string.IsNullOrEmpty(token))
            {
                Assert.Fail("Authorization token is not set.");
            }
           
            try
            {
                var response = await clientService.CreateClientAsync(token, "123451", "Automation Data 1", "test@example.com", "1234567890");

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the content of the response
                    var content = await response.Content.ReadAsStringAsync();

                    dynamic jsonResponse = JsonConvert.DeserializeObject(content);

                    if (jsonResponse.data.id != null)
                    {
                        clientId = Convert.ToInt32(jsonResponse.data.id); // Convert to integer
                    }
                    else
                    {
                        Assert.Fail("Client ID is not present in the response.");
                    }

                    Console.WriteLine($"Client ID: {clientId}"); // Optional: Log the client ID
                }
                else
                {
                    Assert.Fail($"Error creating client: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error creating client: {ex.Message}");
            }
        }

        [When(@"the system create Matter data through API")]
        public async Task WhenTheSystemCreateMatterDataThroughAPI()
        {
            if (clientId <= 0) // Ensure the clientId is valid
            {
                Assert.Fail("Client ID is not set or invalid.");
            }

            var token = GetAuthToken(); // Retrieve the token from BaseClass

            if (string.IsNullOrEmpty(token))
            {
                Assert.Fail("Authorization token is not set.");
            }

            try
            {
                // Call the CreateMatterAsync method
                var response = await clientService.CreateMatterAsync(token, clientId, "Matter Name", "11101830", "INR ₹", new[] { "ad" }, "firm-wide");

                if (response.IsSuccessStatusCode)
                {
                    // Read the content of the response
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response to get the matter ID
                    dynamic jsonResponse = JsonConvert.DeserializeObject(content);

                    // Check if the matter ID is available and convert it to an integer
                    if (jsonResponse.data.id != null)
                    {
                        matterId = Convert.ToInt32(jsonResponse.data.id); // Store the matter ID
                        Console.WriteLine($"Matter ID: {matterId}"); // Log the matter ID
                    }
                    else
                    {
                        Assert.Fail("Matter ID is not present in the response.");
                    }

                    Console.WriteLine("Matter created successfully.");
                }
                else
                {
                    Assert.Fail($"Error creating matter: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error creating matter: {ex.Message}");
            }
        }
        public async Task DeleteMatterAsync(string token, int matterId)
        {
            if (matterId <= 0)
            {
                throw new Exception("Invalid Matter ID provided."); // Ensure valid matter ID
            }

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://dev-api.ils-provision.co.uk/"); // Replace with your actual base URL
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string requestUri = $"api/v1/lawyer/matter/delete/{matterId}";
            Console.WriteLine($"Deleting matter at: {httpClient.BaseAddress}{requestUri}"); // Log the full URL

            var response = await httpClient.DeleteAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error deleting matter: {response.ReasonPhrase}");
            }
        }
    

        [Then(@"the system delete matter data through API")]
        public async Task ThenTheSystemDeleteMatterDataThroughAPI()
        {
            if (matterId <= 0)
            {
                Assert.Fail("Matter ID is not set or invalid.");
            }

            var token = GetAuthToken();

            if (string.IsNullOrEmpty(token))
            {
                Assert.Fail("Authorization token is not set.");
            }

            try
            {
                // Call the DeleteMatterAsync method from the base class
                await DeleteMatterAsync(token, matterId);

                // If the method completes, it means the matter was deleted successfully
                Console.WriteLine($"Matter with ID {matterId} deleted successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error deleting matter: {ex.Message}");
            }
        }
        public async Task DeleteClientAsync(string token, int clientId)
        {
            if (clientId <= 0)
            {
                throw new Exception("Invalid Client ID provided.");
            }

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://dev-api.ils-provision.co.uk/"); 
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string requestUri = $"api/v1/lawyer/client/{clientId}";
            Console.WriteLine($"Deleting client at: {httpClient.BaseAddress}{requestUri}"); 

            var response = await httpClient.DeleteAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error deleting client: {response.ReasonPhrase}");
            }
        }
        [Then(@"the system delete client data through API")]
        public async Task ThenTheSystemDeleteClientDataThroughAPI()
        {
            if (clientId <= 0)
            {
                Assert.Fail("Client ID is not set or invalid.");
            }

            var token = GetAuthToken();

            if (string.IsNullOrEmpty(token))
            {
                Assert.Fail("Authorization token is not set.");
            }

            try
            {
                // Call the DeleteClientAsync method from the base class
                await DeleteClientAsync(token, clientId);

                // If the method completes, it means the client was deleted successfully
                Console.WriteLine($"Client with ID {clientId} deleted successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error deleting client: {ex.Message}");
            }
        }




    }
}

