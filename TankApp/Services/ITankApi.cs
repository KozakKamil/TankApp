using Refit;
using TankApp.Model;

namespace TankApp.Services
{
    public interface ITankApi
    {
        [Get("/api/tanks")]
        Task<List<TankModel>> GetAllTanksAsync();
        [Post("/api/tanks")]
        Task CreateTankAsync([Body] TankModel tank);
    }
}
