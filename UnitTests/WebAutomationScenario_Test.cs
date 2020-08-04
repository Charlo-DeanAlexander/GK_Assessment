using GK_Assessment.TestClasses;
using GK_Assessment.Utilities;
using NUnit.Framework;
using System;
using System.Data;

namespace GK_Assessment.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Selenium_Utilities.CreateDriver();
        }

        [Test]
        public void WebAutomationScenario()
        {
            DataTable TestData = CSV_Utilities.CreateTestDataTable(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\TestData\WebAutomationScenario.csv");

            ProtractorApp_TestClass.NavigateToProtractorApp();
            ProtractorApp_TestClass.AddUsers(TestData);
            ProtractorApp_TestClass.ValidateUsersExist(TestData);
            ProtractorApp_TestClass.DeleteUsers(TestData);
        }

        [TearDown]
        public void TearDown()
        {
            Selenium_Utilities.ShutdownDriver();
        }
    }
}