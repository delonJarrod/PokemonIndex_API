using RapidApid_gaming.Models;

namespace RapidApid_gaming.Interface
{
    public interface IOpenAI
    {

        public Task<PokemonImages> OpenAIImages(string text);
    }
}
