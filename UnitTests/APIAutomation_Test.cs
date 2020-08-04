using GK_Assessment.TestClasses;
using GK_Assessment.Utilities;
using NUnit.Framework;
using System;
using System.Security.Policy;

namespace GK_Assessment.UnitTests
{
    class APIAutomation_Test
    {
        /**
        This test will perform the following objectives:
        1. Perform a GET request against the following endpoint: "https://dog.ceo/api/breeds/list/all"
        2. Display the returned data.
        **/
        [Test]
        public void RetrieveAllDogBreeds()
        {
            string TestResult = null;
            
            TestResult = DogCeoBreed_TestClass.RetrieveAllBreeds();

            Assert.IsNull(TestResult);
        }

        /**
        This test will perform the following objectives:
        1. Perform a GET request against the following endpoint: "https://dog.ceo/api/breeds/list/all"
        2. Display the returned data.
        3. Perform a GET request against the following endpoint "https://dog.ceo/api/breed/hound/list", requesting the following breed data: "hound".
        4. Validate that the requested breed data exists within both responses.
        **/
        [Test]
        public void RetrieveByBreed()
        {
            string TestResult = null;

            TestResult = DogCeoBreed_TestClass.ValidateSubBreedExists("hound");

            Assert.IsNull(TestResult);
        }
    }
}
