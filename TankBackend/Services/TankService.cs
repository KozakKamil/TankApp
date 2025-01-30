using TankBackend.Data;
using TankBackend.Models;

namespace TankBackend.Services;

public class TankService
{
    private readonly ITankRepository _tankRepository;
    public TankService(ITankRepository tankRepository)
    {
        _tankRepository = tankRepository;
    }

    public async Task<List<TankModel>> GetAllTanksAsync()
    {
        return await _tankRepository.GetAllAsync();
    }
    public async Task<TankModel> GetTankByIdAsync(string id)
    {
        return await _tankRepository.GetByIdAsync(id);
    }
    public async Task<TankModel> GetTankByNameAsync(string name)
    {
        return await _tankRepository.GetByNameAsync(name);
    }
    public async Task AddUserAsync(TankModel tank)
    {
        await _tankRepository.AddAsync(tank);
    }
    public async Task UpdateTankAsync(string id, TankModel tank)
    {
        await _tankRepository.UpdateAsync(id, tank);
    }
    public async Task DeleteTankAsync(string id)
    {
        await _tankRepository.DeleteAsync(id);
    }
}
