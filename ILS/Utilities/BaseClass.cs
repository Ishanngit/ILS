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
            driver.Manage().Window.Maximize();
        }
        public static class WaitHelper
        {

            public static IWebElement WaitForElementToBeVisible(IWebDriver driver, By locator, TimeSpan timeout)
            {
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }

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
                if (driver == null)
                {
                    throw new ArgumentNullException("driver", "Driver instance cannot be null");
                }

                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    element.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    IWebElement element = driver.FindElement(locator);
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                    jsExecutor.ExecuteScript("arguments[0].click();", element);
                }
                catch (NoSuchElementException)
                {
                    throw new Exception($"Element with locator {locator} was not found.");
                }
            }
            public static void SelectFromDropdown(IWebDriver driver, By dropdownLocator, string valueToSelect)
            {
                var dropdownElement = FindElement(driver, dropdownLocator);
                if (dropdownElement != null)
                {
                    var selectElement = new SelectElement(dropdownElement);
                    selectElement.SelectByText(valueToSelect);
                }
                else
                {
                    throw new Exception($"Dropdown element with locator {dropdownLocator} not found.");
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
