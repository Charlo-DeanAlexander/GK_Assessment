using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GK_Assessment.Utilities
{
    class Selenium_Utilities
    {
        public static IWebDriver Driver;

        /// <summary>
        /// Creates a static Chrome WebDriver object.
        /// </summary>
        /// <param name="options">Optional parameter to specify chrome options.</param>
        public static void CreateDriver(ChromeOptions options = null)
        {
            if(options == null)
            {
                options = new ChromeOptions();
            }

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Shuts down the static Chrome WebDriver object.
        /// </summary>
        public static void ShutdownDriver()
        {
            Driver.Quit();
        }

        /// <summary>
        /// Navigate to a specified URL using the Chrome WebDriver object.
        /// </summary>
        /// <param name="Url">String representation of a URL</param>
        public static void NavigateToPage(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        /// <summary>
        /// Validate if the provided By Selector exists on the current web page.
        /// </summary>
        /// <param name="Selector">This by selector will be validated.</param>
        /// <param name="TimeOut">Optional parameter which specifies the timeout period for searching for the provided by selector.</param>
        /// <returns>Returns an IWebElement object if the expected element is found</returns>
        public static IWebElement ValidateElementExists(By Selector, int TimeOut = 5)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));

            return wait.Until(element => element.FindElement(Selector));
        }

        /// <summary>
        /// Click an element on the current web page.
        /// </summary>
        /// <param name="Selector">This by selector will be used to specify which element should be clicked.</param>
        public static void ClickElement(By Selector)
        {
            IWebElement element = ValidateElementExists(Selector);
            element.Click();
        }

        /// <summary>
        /// Attempt to send keys to an element on the current page.
        /// </summary>
        /// <param name="Selector">This by selector will be used to identify the element to send keys to.</param>
        /// <param name="TextToEnter">This string represents the keys to be sent to the element.</param>
        /// <param name="ClearText">Optional parameter to clear the element before attempting to send keys.</param>
        public static void EnterText(By Selector, string TextToEnter, bool ClearText = true)
        {
            IWebElement element = ValidateElementExists(Selector);
            
            if(ClearText)
            {
                element.Clear();
            }

            element.SendKeys(TextToEnter);
        }
    }
}
