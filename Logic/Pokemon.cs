using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApid_gaming.Controllers;
using RapidApid_gaming.Interface;
using RapidApid_gaming.Models;
using System;
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
                var response = await GetMethod("https://pokemon-go1.p.rapidapi.com/pokemon_names.json");

                // Check if the JSON is an object instead of an array
                if (response.StartsWith("{"))
                {
                    // Deserialize the JSON to a dictionary
                    Dictionary<string, PokemonName> pokemonDict = JsonConvert.DeserializeObject<Dictionary<string, PokemonName>>(response);
                    // Convert the dictionary to a list
                    List<PokemonName> pokemonList = pokemonDict.Values.ToList();
                    return pokemonList;
                }

                List<PokemonName> pokemonNames = JsonConvert.DeserializeObject<List<PokemonName>>(response);
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
                var response = await GetMethod("https://pokemon-go1.p.rapidapi.com/pokemon_types.json");
                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonNameType> pokemonEvolutions = JsonConvert.DeserializeObject<List<PokemonNameType>>(response);
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
                var response = await GetMethod("https://pokemon-go1.p.rapidapi.com/pokemon_evolutions.json");
                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonEvolution> pokemonEvolutions = JsonConvert.DeserializeObject<List<PokemonEvolution>>(response);
                return pokemonEvolutions.Where(x => x.PokemonName.ToLower() == name.ToLower().Replace(" ", "")).ToList().FirstOrDefault();
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
                var response = await GetMethod("https://pokemon-go1.p.rapidapi.com/pokemon_stats.json");
                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonStats> pokemonStats = JsonConvert.DeserializeObject<List<PokemonStats>>(response);
                // Getting Pokemon Image from OpenAI Image endpoint
                PokemonStats pokeStats = pokemonStats.Where(x => x.PokemonName.ToLower().Replace(" ", "") == name.ToLower().Replace(" ", "")).ToList().FirstOrDefault();
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

                var response = await GetMethod("https://pokemon-go1.p.rapidapi.com/current_pokemon_moves.json");
                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonMoves> pokemonMoves = JsonConvert.DeserializeObject<List<PokemonMoves>>(response);
                return pokemonMoves.Where(x => x.PokemonId == PokeID).ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PokemonMoves> pokemonMovesByName(string PokeName)
        {
            try
            {

                var response = await GetMethod("https://pokemon-go1.p.rapidapi.com/current_pokemon_moves.json");
                // Deserialize the JSON string to a list of PokemonEvolution objects
                List<PokemonMoves> pokemonMoves = JsonConvert.DeserializeObject<List<PokemonMoves>>(response);
                return pokemonMoves.Where(x => x.PokemonName.ToLower().Replace(" ", "") == PokeName.ToLower().Replace(" ", "")).ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<PokemonMovesAndDetails>> pokemonMovesAndDetailsByName(string MoveID)
        {
            try
            {

                var response = await GetMethod("https://pokemon-go1.p.rapidapi.com/fast_moves.json");
                var responseV2 = await GetMethod("https://pokemon-go1.p.rapidapi.com/charged_moves.json");

                // Deserialize the JSON strings to lists of PokemonMovesAndDetails objects
                List<PokemonMovesAndDetails> pokemonMoves = JsonConvert.DeserializeObject<List<PokemonMovesAndDetails>>(response);
                List<PokemonMovesAndDetails> pokemonMovesV2 = JsonConvert.DeserializeObject<List<PokemonMovesAndDetails>>(responseV2);

                // Combine the two lists
                List<PokemonMovesAndDetails> combinedMoves = pokemonMoves.Concat(pokemonMovesV2).ToList();

                return combinedMoves.Where(x => x.move_id.ToLower().Replace(" ", "") == MoveID.ToLower().Replace(" ", "")).ToList();
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


        public async Task<string> GetMethod(string url)
        {
            // Getting the weather data
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
                request.Headers.Add("X-RapidAPI-Host", "pokemon-go1.p.rapidapi.com");
                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}


