using System;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using ILS.Services;
using ILS.Utilities;

namespace ILS.StepDefination
{
    [Binding]
    public class WithAPIPRocessStepDefinitions : BaseClass
    {
        public WithAPIPRocessStepDefinitions() : base() { }

        [When(@"the system fetches the user's additional data from the API in the background")]
        public async Task WhenTheSystemFetchesTheUsersAdditionalDataFromTheAPIInTheBackground()
        {
            var token = GetAuthToken(); // Retrieve the token from BaseClass

            if (string.IsNullOrEmpty(token))
            {
                Assert.Fail("Authorization token is not set.");
            }

            try
            {
                var response = await clientService.CreateClientAsync(token, "12345", "Test Client", "test@example.com", "1234567890");

              
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error creating client: {ex.Message}");
            }
        }
    }
}
