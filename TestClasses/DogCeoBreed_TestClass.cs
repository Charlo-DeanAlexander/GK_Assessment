using GK_Assessment.ModelClasses;
using GK_Assessment.Utilities;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace GK_Assessment.TestClasses
{
    class DogCeoBreed_TestClass
    {
        public static string RetrieveAllBreeds()
        {
            string RequestResult = WebAPI_Utilities.Get("https://dog.ceo/api/breeds/list/all");

            if(string.IsNullOrEmpty(RequestResult))
            {
                return "Failed to retrieve all breeds";
            }

            Console.WriteLine("Retrieved all dog breeds:\n" + RequestResult);

            return null;
        }

        public static string ValidateSubBreedExists(string SubBreed)
        {
            string AllBreedsRequestResult = WebAPI_Utilities.Get("https://dog.ceo/api/breeds/list/all");
            string SubBreedRequestResult = WebAPI_Utilities.Get("https://dog.ceo/api/breed/" + SubBreed + "/list");
            DogCeoBreed_Models.AllBreeds_DogCeoModel AllBreedsRequest_Model = new DogCeoBreed_Models.AllBreeds_DogCeoModel();
            DogCeoBreed_Models.SingleBreed_DogCeoModel SubBreedRequest_Model = new DogCeoBreed_Models.SingleBreed_DogCeoModel();

            if (string.IsNullOrEmpty(AllBreedsRequestResult))
            {
                return "Failed to retrieve all breeds";
            }

            if (string.IsNullOrEmpty(SubBreedRequestResult))
            {
                return "Failed to retrieve data for the sub-breed \"" + SubBreed + "\"";
            }

            AllBreedsRequest_Model = (DogCeoBreed_Models.AllBreeds_DogCeoModel)JsonConvert.DeserializeObject(AllBreedsRequestResult, typeof(DogCeoBreed_Models.AllBreeds_DogCeoModel));
            SubBreedRequest_Model = (DogCeoBreed_Models.SingleBreed_DogCeoModel)JsonConvert.DeserializeObject(SubBreedRequestResult, typeof(DogCeoBreed_Models.SingleBreed_DogCeoModel));

            if(!AllBreedsRequest_Model.message.hound.SequenceEqual(SubBreedRequest_Model.message))
            {
                return "Failed to validate the \"" + SubBreed + "\" sub-breed is returned within all requests.";
            }

            Console.WriteLine("Validated the sub-breed \"" + SubBreed + "\" exists within both requests");

            return null;
        }
    }
}
