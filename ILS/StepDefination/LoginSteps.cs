using ILS.Utilities;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace ILS.StepDefination
{
    [Binding]
    public class LoginSteps : BaseClass
    {
        private readonly WithAPIPRocessStepDefinitions apiProcessSteps;

        public LoginSteps(WithAPIPRocessStepDefinitions apiProcessSteps) : base()
        {
            this.apiProcessSteps = apiProcessSteps;
        }

        [BeforeScenario]
        public void SetUp()
        {
            if (driver == null || driver.Url == "about:blank")
            {
                StartBrowser();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://dev.ils-provision.co.uk/login");
            }
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Navigate().GoToUrl("https://dev.ils-provision.co.uk/login");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email")));
        }

        [When(@"I enter valid email and password")]
        public void WhenIEnterValidUsernameAndPassword()
        {
            var emailInput = WaitHelper.FindElement(driver, By.Id("email"));
            emailInput.SendKeys("automation@simformtest.com");

            var passInput = WaitHelper.FindElement(driver, By.Id("password"));
            passInput.SendKeys("Automation@123");

            // Click on the login button
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
            Thread.Sleep(3000);

            var token = GetTokenFromBrowser();
            if (token != null)
            {
                SetAuthToken(token);
                apiProcessSteps.SetAuthToken(token);
            }
            else
            {
                Assert.Fail("Access token could not be retrieved.");
            }
        }

        [When(@"I clicks on the Clients menu in the side panel")]
        public void WhenIClicksOnTheClientsMenuInTheSidePanel()
        {
            WaitHelper.ClickElement(driver, By.XPath("//span[normalize-space()='Clients']"));
        }

        [When(@"I click on ""([^""]*)"" button")]
        public void WhenIClickOnButton(string p0)
        {
            WaitHelper.ClickElement(driver, By.XPath("//button[@class='ant-btn css-zpynnb ant-btn-primary sc-dLMFU bmwhUr ant-btn-icon-me-0']//span[@class='ant-btn-icon']//*[name()='svg']"));
        }

        [When(@"I add client name ""([^""]*)""")]
        public void WhenIAddClientName(string clientName)
        {
            var emailInput = WaitHelper.FindElement(driver, By.Id("client_name"));
            emailInput.SendKeys(clientName);
        }

        [When(@"I enter client id ""([^""]*)""")]
        public void WhenIEnterClientId(string clientId)
        {
            var emailInput = WaitHelper.FindElement(driver, By.Id("client_id"));
            emailInput.SendKeys(clientId);
        }

        [When(@"I select access  ""([^""]*)""")]
        public void WhenISelectAccess(string firmType)
        {
            WaitHelper.ClickElement(driver, By.XPath("//input[@id='client_type']"));
            WaitHelper.ClickElement(driver, By.XPath("//div[@title='Firm wide']"));
        }

        [When(@"I enter Principal contact email address")]
        public void WhenIEnterPrincipalContactEmailAddress()
        {
            // Generate a unique email
            string uniqueEmail = $"automation_{DateTime.Now:yyyyMMddHHmmssfff}@simformtest.com";
            var emailInput = WaitHelper.FindElement(driver, By.Id("email"));
            emailInput.SendKeys(uniqueEmail);
            Console.WriteLine($"Unique email entered: {uniqueEmail}");
        }

        [Then(@"I click on Add client button")]
        public void ThenIClickOnAddClientButton()
        {
            WaitHelper.ClickElement(driver, By.XPath("//button[@type='submit']"));
        }

        [When(@"I clicks on the Matters menu in the side panel")]
        public void WhenIClicksOnTheMattersMenuInTheSidePanel()
        {
            WaitHelper.ClickElement(driver, By.XPath("//span[normalize-space()='Matters']"));
        }

        [When(@"I click on Add New Matter button")]
        public void WhenIClickOnAddNewMatterButton()
        {
            WaitHelper.ClickElement(driver, By.XPath("//button[@class=\"ant-btn css-zpynnb ant-btn-primary sc-dLMFU bmwhUr ant-btn-icon-me-0\"]"));
        }

        [When(@"I add Matter name ""([^""]*)""")]
        public void WhenIAddMatterName(string MatterName)
        {
            var matterInput = WaitHelper.FindElement(driver, By.Id("matterName"));
            matterInput.SendKeys(MatterName);
        }

        [When(@"I enter Matter id ""([^""]*)""")]
        public void WhenIEnterMatterId(string matterId)
        {
            var idMatter = WaitHelper.FindElement(driver, By.Id("matterId"));
            idMatter.SendKeys(matterId);
        }

        [Then(@"I select client name ""([^""]*)""")]
        public void ThenISelectClientName(string ClientName)
        {
            WaitHelper.ClickElement(driver, By.XPath("//input[@id='clientName']"));
            WaitHelper.ClickElement(driver, By.XPath($"//div[@title='{ClientName}']"));  // Dynamic XPath based on ClientName
        }

        [Then(@"I select Currency ""([^""]*)""")]
        public void ThenISelectCurrency(string currency)
        {
            WaitHelper.ClickElement(driver, By.XPath("//input[@id='currency']"));
            WaitHelper.ClickElement(driver, By.XPath("//div[@title=\"USD $\"]"));
        }

        [Then(@"I add Jurisdiction Test")]
        public void ThenIAddJurisdictionTest()
        {
            var juri = WaitHelper.FindElement(driver, By.XPath("//input[@id='jurisdiction']"));
            juri.SendKeys("This is test");
        }

        [Then(@"Select Matter Type ""([^""]*)""")]
        public void ThenSelectMatterType(string firm)
        {
            WaitHelper.ClickElement(driver, By.XPath("//input[@id='matterType']"));
            WaitHelper.ClickElement(driver, By.XPath("//div[@title=\"Firm wide\"]"));
        }

        [Then(@"I click on Create Matter button")]
        public void ThenIClickOnCreateMatterButton()
        {
            WaitHelper.ClickElement(driver, By.XPath("//button[@class=\"ant-btn css-zpynnb ant-btn-primary sc-dLMFU bmwhUr\"]"));

            By toastMessageLocator = By.XPath("//div[@class='ant-message-notice-content']");
            IWebElement toastElement = WaitHelper.WaitForElementToBeVisible(driver, toastMessageLocator, TimeSpan.FromSeconds(10));


            Thread.Sleep(3000);

        }

        [Then(@"I click on delete button")]
        public void ThenIClickOnDeleteButton()
        {
            WaitHelper.ClickElement(driver, By.XPath("//a[@class='sc-ddjGPC icstSb'][2]"));
        }

        [Then(@"I click on delete")]
        public void ThenIClickOnDelete()
        {
            WaitHelper.ClickElement(driver, By.XPath("//button[@class=\"ant-btn css-zpynnb ant-btn-primary ant-btn-block ant-btn-dangerous sc-dLMFU bmwhUr\"]"));
        }

        [When(@"I click on delete client button")]
        public void WhenIClickOnDeleteClientButton()
        {
            WaitHelper.ClickElement(driver, By.XPath("//tbody//button[2]//*[name()='svg']"));
        }

        [When(@"I click on delete button on confirmation model")]
        public void WhenIClickOnDeleteButtonOnConfirmationModel()
        {
            WaitHelper.ClickElement(driver, By.XPath("//button[@class=\"ant-btn css-zpynnb ant-btn-primary ant-btn-block ant-btn-dangerous sc-dLMFU bmwhUr\"]"));

            Thread.Sleep(3000);
        }

        [AfterScenario]
        public void CleanUp()
        {
            if (driver != null)
            {
                driver.Close();
                StopBrowser();
            }
        }
    }
}
