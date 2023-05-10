using Microsoft.AspNetCore.Mvc;
using RapidApid_gaming.Interface;
using RapidApid_gaming.Models;

namespace RapidApid_gaming.Controllers
{
    public class OpenAIController : ControllerBase
    {

        private readonly IOpenAI _OpenAI;

        public OpenAIController(IOpenAI OpenAI)
        {
            _OpenAI = OpenAI;
        }

        [HttpPost]
        [Route("Post_Open_AI_Image")]
        public async Task<PokemonImages> postOpenAIImage(string Text)
        {
            return (PokemonImages)await _OpenAI.OpenAIImages(Text);
        }
    }
}
