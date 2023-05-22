using RapidApid_gaming.Logic;
using RapidApid_gaming.Models;

namespace RapidApid_gaming.Interface
{
    public interface IPokemon
    {
        public Task<List<PokemonName>> pokemonNames();
        public Task<List<PokemonNameType>> pokemonNamesAndTypes();
        public Task<PokemonEvolution> pokemonEvolution(string name);
        public Task<PokemonStats> pokemonStats(string name);
        public Task<PokemonMoves> pokemonMoves(int PokeID);
        public Task<PokemonMoves> pokemonMovesByName(string PokeName);
        public Task<List<PokemonMovesAndDetails>> pokemonMovesAndDetailsByName(string MoveID);
        public Task<PokemonDetails> pokemonFullDetails(string name);
    }
}
