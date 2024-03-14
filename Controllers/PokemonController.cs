using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReviewWebAPI.Models.DTO;
using ReviewWebAPI.Repositories.Implementation;
using ReviewWebAPI.Repositories.Interface;
using ReviewWebAPI.Models.Domain;

namespace ReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
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
                    Id = pokemon.Id,
                    BirthDate = pokemon.BirthDate,
                    Name = pokemon.Name
                });
            }

            return Ok(reponse);
        }


        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetPokemonById([FromRoute] int id)
        {
            var existingPokemon = await pokemonRepository.GetByIdAsync(id);

            if (existingPokemon == null)
            {
                return NotFound();
            }

            var response = new PokemonDTO
            {
                Id = existingPokemon.Id,
                Name = existingPokemon.Name,
                BirthDate = existingPokemon.BirthDate
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePokemon(CreatePokemonDTO request)
        {
            //Convert DTO to Domain model
            var Pokemons = new Pokemon
            {
                Name = request.Name,
                BirthDate = request.BirthDate
            };
            await pokemonRepository.CreateAsync(Pokemons);

            //Map Domain Model to DTO
            var response = new PokemonDTO
            {
                Id = Pokemons.Id,
                Name = Pokemons.Name,
                BirthDate = Pokemons.BirthDate
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var Pokemon = await pokemonRepository.DeleteAsync(id);
            if(Pokemon is null)
            {
                return NotFound();

            }

            var response = new PokemonDTO
            {
                Id = Pokemon.Id,
                Name = Pokemon.Name,
                BirthDate = Pokemon.BirthDate
            };

            return Ok(response);

        }

       



    }
}
