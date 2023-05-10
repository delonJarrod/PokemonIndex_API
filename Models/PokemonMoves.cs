using Newtonsoft.Json;

namespace RapidApid_gaming.Models
{
    public class PokemonMoves
    {
        [JsonProperty("charged_moves")]
        public List<string> ChargedMoves { get; set; }

        [JsonProperty("elite_charged_moves")]
        public List<string> EliteChargedMoves { get; set; }

        [JsonProperty("elite_fast_moves")]
        public List<string> EliteFastMoves { get; set; }

        [JsonProperty("fast_moves")]
        public List<string> FastMoves { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("pokemon_id")]
        public int PokemonId { get; set; }


        [JsonProperty("pokemon_name")]
        public string PokemonName { get; set; }


    }
   

}
