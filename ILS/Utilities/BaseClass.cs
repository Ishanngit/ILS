using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;


namespace ILS.Utilities
{
    public class BaseClass
    {
        public IWebDriver driver { get; private set; }

        public void StartBrowser()
        {
            try
            {
                driver = new ChromeDriver();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting the browser: {ex.Message}");
                throw; // Re-throw the exception if necessary
            }
        }
        public static class WaitHelper
        {

            public static IWebElement WaitForElementToBeVisible(IWebDriver driver, By locator, TimeSpan timeout)
            {
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }

            // Method to find an element by locator (By) with a default timeout of 10 seconds
            public static IWebElement FindElement(IWebDriver driver, By locator)
            {
                TimeSpan defaultTimeout = TimeSpan.FromSeconds(10);
                WebDriverWait wait = new WebDriverWait(driver, defaultTimeout);

                return wait.Until(d =>
                {
                    try
                    {
                        return d.FindElement(locator);
                    }
                    catch (NoSuchElementException)
                    {
                        return null; // Return null if the element is not found yet
                    }

                });

            }
            public static void ClickElement(IWebDriver driver, By locator)
            {
                IWebElement element = FindElement(driver, locator); // Use the FindElement method to locate the element

                if (element != null)
                {
                    element.Click(); // Click the element
                }
                else
                {
                    throw new NoSuchElementException($"Element with locator '{locator}' was not found.");
                }
            }
        }
            public void StopBrowser()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
