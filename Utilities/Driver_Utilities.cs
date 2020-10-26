using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace GK_Assessment.Utilities
{
    class Driver_Utilities
    {
        public static IWebDriver Driver;

        /// <summary>
        /// Creates a static Chrome WebDriver object.
        /// </summary>
        /// <param name="options">Optional parameter to specify which driver options should be created.</param>
        public static void CreateDriver(ChromeOptions options = null)
        {
            if (options == null)
            {
                options = new ChromeOptions();
            }

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Creates a static Android WebDriver object.
        /// </summary>
        /// <param name="DeviceName">Specifies the device name to be connected to</param>
        /// <param name="PlatformVersion">Specifies the device OS version</param>
        public static void CreateAndroidDriver(string DeviceName, string PlatformVersion)
        {
            Uri url = new Uri("http://127.0.0.1:4723/wd/hub");

            Driver = new AndroidDriver<AndroidElement>(url, CreateMobileDeviceCapabilities(DeviceName, PlatformVersion));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        /// <summary>
        /// Creates default mobile device capabilities for the Universal Music Player application.
        /// </summary>
        /// <param name="DeviceName">Specifies the device name to be connected to</param>
        /// <param name="PlatformVersion">Specifies the device OS version</param>
        /// <returns></returns>
        private static AppiumOptions CreateMobileDeviceCapabilities(string DeviceName, string PlatformVersion)
        {
            AppiumOptions options = new AppiumOptions();
            options.PlatformName = "Android";
            options.AddAdditionalCapability("deviceName", DeviceName);
            options.AddAdditionalCapability("platformVersion", PlatformVersion);
            options.AddAdditionalCapability("automationName", "UiAutomator2");
            options.AddAdditionalCapability("app", AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\apkFiles\android-ump-mobile-debug-67a35ff.apk");
            options.AddAdditionalCapability("appPackage", "com.example.android.uamp");
            options.AddAdditionalCapability("appActivity", "com.example.android.uamp.ui.MusicPlayerActivity");

            return options;
        }

        /// <summary>
        /// Shuts down the static WebDriver object.
        /// </summary>
        public static void ShutdownDriver()
        {
            if(Driver != null)
            {
                Driver.Quit();
            }
        }

        /// <summary>
        /// Navigate to a specified URL using the WebDriver object.
        /// </summary>
        /// <param name="Url">String representation of a URL</param>
        public static void NavigateToPage(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        /// <summary>
        /// Validate if the provided By Selector exists on the page.
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
        /// Click an element on the current page.
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
