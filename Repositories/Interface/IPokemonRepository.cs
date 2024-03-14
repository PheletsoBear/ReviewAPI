using ReviewWebAPI.Models.Domain;

namespace ReviewWebAPI.Repositories.Interface
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetAllAsync();
        Task<Pokemon?> GetByIdAsync(int id);
        Task<Pokemon> CreateAsync(Pokemon pokemon);

    }
}
