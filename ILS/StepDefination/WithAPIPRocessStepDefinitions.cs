using TechTalk.SpecFlow;
using NUnit.Framework;
using ILS.Services;
using ILS.Utilities;

namespace ILS.StepDefination
{
    [Binding]
    public class WithAPIPRocessStepDefinitions : BaseClass
    {
        protected string authToken; // Change access modifier to protected

        public WithAPIPRocessStepDefinitions() : base()
        {
            // ClientService is automatically initialized via DI
        }

        public void SetAuthToken(string token) // Method to set the auth token
        {
            authToken = token;
        }

        [When(@"the system fetches the user's additional data from the API in the background")]
        public async Task WhenTheSystemFetchesTheUsersAdditionalDataFromTheAPIInTheBackground()
        {
            if (string.IsNullOrEmpty(authToken))
            {
                Assert.Fail("Authorization token is not set.");
            }

            // Use clientService to call the API
            var response = await clientService.CreateClientAsync(authToken, "12345", "Test Client", "test@example.com", "1234567890");

            // Uncomment the following line to verify the response if needed
            // Assert.IsNotNull(response);
        }
    }
}
