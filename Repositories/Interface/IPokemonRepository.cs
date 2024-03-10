using ReviewWebAPI.Models.Domain;

namespace ReviewWebAPI.Repositories.Interface
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetAllAsync();

    }
}
