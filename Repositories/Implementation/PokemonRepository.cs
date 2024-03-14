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
