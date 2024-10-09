using ILS.Utilities;
using OpenQA.Selenium;
using static ILS.Utilities.BaseClass;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

[Binding]
public class LoginSteps : BaseClass
{
    [BeforeScenario]
    public void SetUp()
    {
        StartBrowser(); 
        driver.Manage().Window.Maximize();
    }

    [Given(@"I am on the login page")]
    public void GivenIAmOnTheLoginPage()
    {
        driver.Navigate().GoToUrl("https://dev.ils-provision.co.uk/login");
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
        WaitHelper.ClickElement(driver, By.XPath("//button[@type='submit']"));
    }
  

    [When(@"I enter OTP")]
    public void WhenIEnterOTP()
    {
        string receivedOtp = "111111"; 
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        var otpInputs = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".input-otp__field")));

        for (int i = 0; i < receivedOtp.Length; i++)
        {
           
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(otpInputs[i]));
            otpInputs[i].Click();
            otpInputs[i].SendKeys(receivedOtp[i].ToString()); 
        }
    }

    [When(@"I click on Verify Button")]
    public void WhenIClickOnVerifyButton()
    {
        WaitHelper.ClickElement(driver, By.XPath("//button[@type='submit']"));
    }


    [AfterScenario]
    public void CleanUp()
    {
        StopBrowser(); 
    }
}
