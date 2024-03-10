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

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            return await dbContext.Pokemon.ToListAsync();
        }
    }
}
