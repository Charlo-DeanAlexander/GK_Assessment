using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GK_Assessment.Utilities
{
    class Selenium_Utilities
    {
        public static IWebDriver Driver;

        public static void CreateDriver(ChromeOptions options = null)
        {
            if(options == null)
            {
                options = new ChromeOptions();
            }

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
        }

        public static void ShutdownDriver()
        {
            Driver.Quit();
        }

        public static void NavigateToPage(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public static IWebElement ValidateElementExists(By Selector, int TimeOut = 5)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));

            return wait.Until(element => element.FindElement(Selector));
        }

        public static void ClickElement(By Selector)
        {
            IWebElement element = ValidateElementExists(Selector);
            element.Click();
        }

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
