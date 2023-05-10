using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApid_gaming.Controllers;
using RapidApid_gaming.Interface;
using RapidApid_gaming.Models;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace RapidApid_gaming.Logic
{
    public class Pokemon : IPokemon
    {
        private readonly IConfiguration _mySettings;
        private static OpenAIController _OpenAI;
       
        private static readonly HttpClient _httpClient = new HttpClient();

        public Pokemon(IConfiguration mySettings, OpenAIController OpenAI)
        {
            _mySettings = mySettings;
            _OpenAI = OpenAI;
        }

        public async Task<List<PokemonName>> pokemonNames()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://pokemon-go1.p.rapidapi.com/pokemon_names.json");
                request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
                request.Headers.Add("X-RapidAPI-Host", "pokemon-go1.p.rapidapi.com");

                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                // Check if the JSON is an object instead of an array
                if (body.StartsWith("{"))
                {
                    // Deserialize the JSON to a dictionary
                    Dictionary<string, PokemonName> pokemonDict = JsonConvert.DeserializeObject<Dictionary<string, PokemonName>>(body);

                    // Convert the dictionary to a list
                    List<PokemonName> pokemonList = pokemonDict.Values.ToList();

                    return pokemonList;
                }

                List<PokemonName> pokemonNames = JsonConvert.DeserializeObject<List<PokemonName>>(body);
                return pokemonNames;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<PokemonNameType>> pokemonNamesAndTypes()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://pokemon-go1.p.rapidapi.com/pokemon_types.json");
                request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
                request.Headers.Add("X-RapidAPI-Host", "pokemon-go1.p.rapidapi.com");

                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();


               

                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonNameType> pokemonEvolutions = JsonConvert.DeserializeObject<List<PokemonNameType>>(body);
                return pokemonEvolutions.Where(x => x.Form.ToLower() == "normal").ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PokemonEvolution> pokemonEvolution(string name)
        {
            try
            {
                // Getting the evolutions
                var request = new HttpRequestMessage(HttpMethod.Get, "https://pokemon-go1.p.rapidapi.com/pokemon_evolutions.json");
                request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
                request.Headers.Add("X-RapidAPI-Host", "pokemon-go1.p.rapidapi.com");
                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonEvolution> pokemonEvolutions = JsonConvert.DeserializeObject<List<PokemonEvolution>>(body);
                return pokemonEvolutions.Where(x => x.PokemonName.ToLower() == name.ToLower()).ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PokemonStats> pokemonStats(string name)
        {
            try
            {

                // Getting the evolutions
                var request = new HttpRequestMessage(HttpMethod.Get, "https://pokemon-go1.p.rapidapi.com/pokemon_stats.json");
                request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
                request.Headers.Add("X-RapidAPI-Host", "pokemon-go1.p.rapidapi.com");
                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonStats> pokemonStats = JsonConvert.DeserializeObject<List<PokemonStats>>(body);

                // Getting Pokemon Image from OpenAI Image endpoint
                PokemonStats pokeStats = pokemonStats.Where(x => x.PokemonName.ToLower() == name.ToLower()).ToList().FirstOrDefault();
                return pokeStats;
            
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PokemonMoves> pokemonMoves(int PokeID)
        {
            try
            {

                // Getting the evolutions
                var request = new HttpRequestMessage(HttpMethod.Get, "https://pokemon-go1.p.rapidapi.com/current_pokemon_moves.json");
                request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
                request.Headers.Add("X-RapidAPI-Host", "pokemon-go1.p.rapidapi.com");
                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();


                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonMoves> pokemonMoves = JsonConvert.DeserializeObject<List<PokemonMoves>>(body);
                return pokemonMoves.Where(x => x.PokemonId == PokeID).ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PokemonDetails> pokemonFullDetails(string name)
        {
            try
            {

                PokemonEvolution Evolution = await pokemonEvolution(name);
                PokemonStats Stats = await pokemonStats(name);
                PokemonDetails pokemonDetails = new PokemonDetails();
                pokemonDetails.PokemonEvolution = Evolution;
                pokemonDetails.PokemonStats = Stats;

                // Deserialize the JSON string to a list of PokemonEvolution objects
                return pokemonDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}


