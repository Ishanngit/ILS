using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class WebDriverManager
{   
    public IWebDriver driver { get; private set; }

    public void StartBrowser()
    {
        try
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://dev.ils-provision.co.uk/login");
            driver.Manage().Window.Maximize();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error starting the browser: {ex.Message}");
            throw; // Re-throw the exception if necessary
        }
    }
    public static IWebElement FindElementByXPath(IWebDriver driver, string xpath, TimeSpan timeout)
    {
        var wait = new WebDriverWait(driver, timeout);
        return wait.Until(d => d.FindElement(By.XPath(xpath)));
    }


    public void WaitUntillElementVisible(By Locator)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementToBeClickable(Locator));
    }
    public void StopBrowser()
    {
        driver.Quit();
        driver.Dispose();
    }
}
