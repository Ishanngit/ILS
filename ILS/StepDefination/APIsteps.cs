using ILS.Utilities;
using OpenQA.Selenium;
using static ILS.Utilities.BaseClass;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

[Binding]
public class APIsteps : BaseClass
{
    [BeforeScenario]
    public void SetUp()
    {
        StartBrowser();
    }
    [When(@"the system fetches the user's additional data from the API in the background")]
    public async Task WhenTheSystemFetchesUserAdditionalDataFromBackgroundApi()
    {
        // Make the API call in the background
        _userData = await _userService.FetchUserDataAsync();  
    }
}