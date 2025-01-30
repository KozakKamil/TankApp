using TankBackend.Models;

namespace TankBackend.Data;

public interface ITankRepository : IMongorepository<TankModel>
{
    Task<TankModel> GetByNameAsync(string name);
}
