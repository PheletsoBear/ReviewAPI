using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReviewWebAPI.Models.DTO;
using ReviewWebAPI.Repositories.Implementation;
using ReviewWebAPI.Repositories.Interface;

namespace ReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository pokemonRepository;

        public PokemonController( IPokemonRepository pokemonRepository)
        {
            this.pokemonRepository = pokemonRepository;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllPokemons()
        {
            var Pokemons = await pokemonRepository.GetAllAsync();

            var reponse = new List<PokemonDTO>();
            foreach (var pokemon in Pokemons)
            {
                reponse.Add(new PokemonDTO
                {
                    BirthDate = pokemon.BirthDate,
                    Name = pokemon.Name
                });   
            }

            return Ok(reponse);
        }




    }
}
