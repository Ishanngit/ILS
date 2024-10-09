using ILS.Utilities;
using OpenQA.Selenium;
using static ILS.Utilities.BaseClass;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

[Binding]
public class CreateClient : BaseClass
{
    private WebDriverWait wait;

    public CreateClient()
    {
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // Use the driver from the BaseClass
    }

 
    [When(@"I clicks on the ""([^""]*)"" menu in the side panel")]
    public void WhenIClicksOnTheMenuInTheSidePanel(string Clients)
    {
        var menu = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//li[@data-menu-id='rc-menu-uuid-88386-1-client-list']")));
        menu.Click();
    }



}
/*
[When(@"I click on ""([^""]*)"" button")]
    public void WhenIClickOnButton(string p0)
    {
        throw new PendingStepException();
    }*/




/*[When(@"I add client name ""(.*)""")]
public void WhenIAddClientName(string clientNameInput)
{
    var clientName = WaitHelper.FindElement(driver, By.Id("client_name"));
    clientName.SendKeys(clientNameInput);
}

[When(@"I enter client id ""(.*)""")]
public void WhenIEnterClientId(string clientId)
{
    driver.FindElement(By.Id("clientId")).SendKeys(clientId);
}*/
/*
    [When(@"I select access ""(.*)""")]
    public void WhenISelectAccess(string accessLevel)
    {
        var accessDropdown = driver.FindElement(By.Id("accessDropdown")); // Replace with actual dropdown ID
        var selectElement = new SelectElement(accessDropdown);
        selectElement.SelectByText(accessLevel);
    }

    [Then(@"I should see a confirmation message ""(.*)""")]
    public void ThenIShouldSeeAConfirmationMessage(string expectedMessage)
    {
        var confirmationMessage = driver.FindElement(By.Id("confirmationMessage")).Text; // Replace with actual ID
        Assert.AreEqual(expectedMessage, confirmationMessage);
    }*/
