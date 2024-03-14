using Microsoft.EntityFrameworkCore;
using ReviewWebAPI.Data;
using ReviewWebAPI.Models.Domain;
using ReviewWebAPI.Repositories.Interface;

namespace ReviewWebAPI.Repositories.Implementation
{
    public class PokemonRepository: IPokemonRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PokemonRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Pokemon> CreateAsync(Pokemon pokemon)
        {
            await dbContext.AddAsync(pokemon);
            await dbContext.SaveChangesAsync();
            return pokemon;
        }

        public async Task<Pokemon> DeleteAsync(int id)
        {
            var existingPokemon = await dbContext.Pokemon.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPokemon is null)
            {
                return null;
            }
            else
            {
                dbContext.Pokemon.Remove(existingPokemon);
                await dbContext.SaveChangesAsync();
                return existingPokemon;
            }
        }

        public Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pokemon?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
   

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            return await dbContext.Pokemon.ToListAsync();
        }

        public async Task<Pokemon?> GetByIdAsync(int id)
        {
            return await dbContext.Pokemon.FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
