using OpenQA.Selenium;
using TechTalk.SpecFlow;



namespace ILS_Project.StepDefination

{
    [Binding]
    public class LoginSteps 

    {
        private IWebDriver driver;
     

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {

            //driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://dev.ils-provision.co.uk/login");
            driver.Manage().Window.Maximize();

        }


        [When(@"I enter valid username")]
        public void WhenIEnterValidUsername()
        {
           


            var emailInput = driver.FindElement(By.XPath("//input[@id='email']")); 
        
            emailInput.SendKeys("email");

        }

        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
          //  driver.FindElement(By.Name("Login")).Click();
        }

        [Then(@"I should be redirected to the dashboard page")]
        public void ThenIShouldBeRedirectedToTheDashboardPage()
        {
          //  Assert.That(driver.Url, Is.EqualTo("https://dev.ils-provision.co.uk/"));
        }

      

        [TearDown]
        public void CleanUp()
        {

            driver.Quit();

        }
    }
}
