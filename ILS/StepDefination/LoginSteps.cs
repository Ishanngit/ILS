using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ILS.Utilities;


namespace ILS.StepDefination

{
    [Binding]
    public class LoginSteps : BaseClass

    {
        private IWebDriver driver;
    
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Navigate().GoToUrl("https://dev.ils-provision.co.uk/login");
            driver.Manage().Window.Maximize();
        }

        [When(@"I enter valid email and password")]
        public void WhenIEnterValidUsernameAndPassword()
        {
            var emailInput = WaitHelper.FindElement(driver, By.Id("email"));

            emailInput.SendKeys("automation@simformtest.com");

            var passInput = WaitHelper.FindElement(driver, By.Id("password"));

            passInput.SendKeys("Automation@123");
        }

        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            WaitHelper.ClickElement(driver, By.Name("Login"));
        }

        [Then(@"I should be redirected to the dashboard page")]
        public void ThenIShouldBeRedirectedToTheDashboardPage()
        {
           Assert.That(driver.Url, Is.EqualTo("https://dev.ils-provision.co.uk/"));
        }

      

        [TearDown]
        public void CleanUp()
        {

            driver.Quit();

        }
    }
}
