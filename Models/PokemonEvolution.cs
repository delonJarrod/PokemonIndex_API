using Newtonsoft.Json;

namespace RapidApid_gaming.Models
{
    public class PokemonEvolution
    {
        [JsonProperty("pokemon_id")]
        public int PokemonId { get; set; }

        [JsonProperty("pokemon_name")]
        public string PokemonName { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("evolutions")]
        public List<EvolutionDetails> Evolutions { get; set; }
    }
    public class EvolutionDetails
    {
        [JsonProperty("pokemon_id")]
        public int PokemonId { get; set; }

        [JsonProperty("pokemon_name")]
        public string PokemonName { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("candy_required")]
        public int CandyRequired { get; set; }
    }
}
