using Newtonsoft.Json;

namespace RapidApid_gaming.Models
{
    public class PokemonMovesAndDetails
    {
        [JsonProperty("critical_chance")]
        public string critical_chance { get; set; }
        [JsonProperty("duration")]
        public string duration { get; set; }
        [JsonProperty("energy_delta")]
        public string energy_delta { get; set; }
        [JsonProperty("move_id")]
        public string move_id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("power")]
        public string power { get; set; }
        [JsonProperty("stamina_loss_scaler")]
        public string stamina_loss_scaler { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
    }
}
