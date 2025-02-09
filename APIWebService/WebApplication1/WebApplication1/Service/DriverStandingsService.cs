using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;

namespace WebApplication1.Service
{
    public class DriverStandingsService
    {
        private readonly HttpClient _httpClient;

        public DriverStandingsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://pitwall.redbullracing.com/");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "7303c8ef-d91a-4964-a7e7-78c26ee17ec4");
        }



        public async Task<List<DriverStanding>> GetDriverStandingsAsync(int season)
        {

            var response = await _httpClient.GetAsync($"api/standings/drivers/{season}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error retrieving data from API");
            }

            var contentType = response.Content.Headers.ContentType?.MediaType;

            if (contentType == "application/json")
            {
                // Handle JSON response
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Log the raw JSON response
                Console.WriteLine("JSON Response:");
                Console.WriteLine(jsonResponse);

                return JsonSerializer.Deserialize<List<DriverStanding>>(jsonResponse);
            }
            else if (contentType == "application/xml" || contentType == "text/xml")
            {
                // Handle XML response
                var xmlResponse = await response.Content.ReadAsStreamAsync();

                // Log the raw XML response (optional)
                using (var reader = new StreamReader(xmlResponse))
                {
                    Console.WriteLine("XML Response:");
                    Console.WriteLine(await reader.ReadToEndAsync());
                }

                xmlResponse.Position = 0; // Reset the stream position to the beginning
                var serializer = new XmlSerializer(typeof(List<DriverStanding>));
                return (List<DriverStanding>)serializer.Deserialize(xmlResponse);
            }
            else
            {
                throw new Exception($"Unsupported Content-Type: {contentType}");
            }
        }
    }
}
