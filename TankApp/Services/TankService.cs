

using TankApp.Model;

namespace TankApp.Services;

public class TankService
{
    private readonly ITankApi _api;

    public TankService(ITankApi api)
    {
        _api = api;
    }

    public async Task<List<TankModel>> GetTanksAsync() => await _api.GetAllTanksAsync();
    public async Task AddTankAsync(TankModel tank) => await _api.CreateTankAsync(tank);
}
