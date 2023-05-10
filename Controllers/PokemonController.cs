using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using RapidApid_gaming.Interface;
using RapidApid_gaming.Models;

namespace RapidApid_gaming.Controllers
{
    public class PokemonController : ControllerBase
    {

        private readonly IPokemon _pokemon;

        public PokemonController (IPokemon pokemon)
        {
            _pokemon = pokemon;
        }

        [HttpGet]
        [Route("Get_Pokemon_Names")]
        public async Task<ActionResult<IEnumerable<PokemonName>>> getPokemonNames()
        {
            return Ok(await _pokemon.pokemonNames());
        }

        [HttpGet]
        [Route("Get_Pokemon_Names_And_Type")]
        public async Task<ActionResult<IEnumerable<PokemonName>>> getPokemonNamesAndTypes()
        {
            return Ok(await _pokemon.pokemonNamesAndTypes());
        }

        [HttpPost]
        [Route("Post_Pokemon_Evolution")]
        public async Task<ActionResult<IEnumerable<PokemonName>>> postPokemonEvolution(string name)
        {
            return Ok(await _pokemon.pokemonEvolution(name));
        }

        [HttpPost]
        [Route("Post_Pokemon_Stats")]
        public async Task<ActionResult<IEnumerable<PokemonName>>> postPokemonStats(string name)
        {
            return Ok(await _pokemon.pokemonStats(name));
        }

        [HttpPost]
        [Route("Post_Pokemon_Moves")]
        public async Task<ActionResult<IEnumerable<PokemonMoves>>> postPokemonMoves(int PokeID)
        {
            return Ok(await _pokemon.pokemonMoves(PokeID));
        }
        [HttpPost]
        [Route("Post_Pokemon_Full_Details")]
        public async Task<ActionResult<IEnumerable<PokemonName>>> postPokemonFullDetails(string name)
        {
            return Ok(await _pokemon.pokemonFullDetails(name));
        }
    }
}
