using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GK_Assessment.Utilities
{
    class WebAPI_Utilities
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Create a GET request against the specified URL.
        /// </summary>
        /// <param name="url">GET request endpoint</param>
        /// <returns>A string containing the JSON payload.</returns>
        public static string Get(string url)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = client.GetAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("GET API request failed:\n" + response.Content.ReadAsStringAsync().Result);
                    return null;
                }

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to perform GET API request");
                Console.WriteLine("[ERROR]:\n" + e.Message);
                return null;
            }
        }
    }
}
