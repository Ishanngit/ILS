using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using ILS.Services;
using ILS.Utilities;
using Newtonsoft.Json;

namespace ILS.StepDefination
{
    [Binding]
    public class WithAPIPRocessStepDefinitions : BaseClass
    {
        private int clientId; // Class-level variable to store the client ID

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
                var response = await clientService.CreateClientAsync(token, "12345", "Test Client", "test@example.com", "1234567890");

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the content of the response
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response to get the client ID
                    dynamic jsonResponse = JsonConvert.DeserializeObject(content);

                    // Check if the id is available and convert it to an integer
                    if (jsonResponse.data.id != null)
                    {
                        clientId = Convert.ToInt32(jsonResponse.data.id); // Convert to integer
                    }
                    else
                    {
                        Assert.Fail("Client ID is not present in the response.");
                    }

                    // Log the client ID
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
            // Use the clientId stored from the previous step
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

                if (!response.IsSuccessStatusCode)
                {
                    Assert.Fail($"Error creating matter: {response.ReasonPhrase}");
                }

                // Optionally log the successful creation of the matter
                Console.WriteLine("Matter created successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error creating matter: {ex.Message}");
            }
        }
    }
}
