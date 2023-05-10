using Newtonsoft.Json;

namespace RapidApid_gaming.Models
{
    public class PokemonNameType
    {
        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("pokemon_id")]
        public int PokemonId { get; set; }

        [JsonProperty("pokemon_name")]
        public string PokemonName { get; set; }

        [JsonProperty("type")]
        public List<string> Type { get; set; }
    }
}
