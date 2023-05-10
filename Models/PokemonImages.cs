using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RapidApid_gaming.Models
{
    public class PokemonImages
    {
        public int created { get; set; }
        public List<ImageData> data { get; set; }
    }

    public class ImageData
    {
        public string Url { get; set; }
    }

}
