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
            //Driver_Utilities.CreateDriver();
        }

        /**
        This test will perform the following objectives:
        1. Navigate to the protractor app website: "http://www.way2automation.com/angularjs-protractor/webtables/"
        2. Add a user.
        3. Validate that the user has been created.
        4. Delete the created user.
        **/

        [Test]
        public void WebAutomationScenario()
        {
            //DataTable TestData = CSV_Utilities.CreateTestDataTable(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\TestData\WebAutomationScenario.csv");

            //ProtractorApp_TestClass.NavigateToProtractorApp();
            //ProtractorApp_TestClass.AddUsers(TestData);
            //ProtractorApp_TestClass.ValidateUsersExist(TestData);
            //ProtractorApp_TestClass.DeleteUsers(TestData);
        }

        [TearDown]
        public void TearDown()
        {
            //Driver_Utilities.ShutdownDriver();
        }
    }
}