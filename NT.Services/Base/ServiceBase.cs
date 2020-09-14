using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using NT.Entities;

namespace NT.Services.Base
{
    public abstract class ServiceBase
    {
        /// <summary>
        /// Calls a given endpoint and returns a string with the retrieved json data
        /// </summary>
        /// <param name="url"></param>
        /// <returns>A <see cref="string"/> containing JSON Data</returns>
        /// <exception cref="WebServiceException"></exception>
        protected virtual async Task<string> CallWebApiAsync(string url)
        {
            try
            {
                // Create a HttpWebRequest
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
                // Set method to get
                httpWebRequest.Method = WebRequestMethods.Http.Get;
                // Set accept headers
                httpWebRequest.Accept = "application/json";

                // String for storing the json data retrieved from the endpoint
                string result;

                // Get response from the website
                using(HttpWebResponse response = await httpWebRequest.GetResponseAsync() as HttpWebResponse)
                {
                    // Read the response
                    using StreamReader sr = new StreamReader(response.GetResponseStream());
                    // Assign the response data to the result variable
                    result = await sr.ReadToEndAsync();
                };

                // Return the retrieved JSON data.
                return result;
            }
            catch(Exception ex)
            {
                throw new WebServiceException("Der kunne ikke oprettes forbindelse til slutpunktet. Se den indre fejl for detaljer.", ex);
            }
        }
    }
}