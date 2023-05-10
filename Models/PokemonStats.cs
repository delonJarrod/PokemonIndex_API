using Newtonsoft.Json;

namespace RapidApid_gaming.Models
{
    public class PokemonStats
    {
        [JsonProperty("base_attack")]
        public int BaseAttack { get; set; }

        [JsonProperty("base_defense")]
        public int BaseDefense { get; set; }

        [JsonProperty("base_stamina")]
        public int BaseStamina { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("pokemon_id")]
        public int PokemonId { get; set; }

        [JsonProperty("pokemon_name")]
        public string PokemonName { get; set; }

    }
}
