using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;
using RapidApid_gaming.Controllers;
using RapidApid_gaming.Interface;
using RapidApid_gaming.Models;
using RestSharp;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Nodes;

namespace RapidApid_gaming.Logic
{
    public class OpenAI : IOpenAI
    {

        private readonly IConfiguration _mySettings;

        private static readonly HttpClient _httpClient = new HttpClient();

        public OpenAI(IConfiguration mySettings)
        {
            _mySettings = mySettings;
        }

        public async Task<PokemonImages> OpenAIImages(string text)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://openai80.p.rapidapi.com/images/generations"),
                    Headers ={
                              { "X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342" },
                              { "X-RapidAPI-Host", "openai80.p.rapidapi.com" },
                             },
                    Content = new StringContent("{\r\"prompt\": \"acurate image of "+ text + " from pokemon\",\r\"n\": 1,\r\"size\": \"1024x1024\"\r}")

                            {
                    Headers ={ContentType = new MediaTypeHeaderValue("application/json")}
                            }
            };
                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON to a single PokemonImages object
                    PokemonImages pokemonImages = JsonConvert.DeserializeObject<PokemonImages>(body);
                    return pokemonImages;
             
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
