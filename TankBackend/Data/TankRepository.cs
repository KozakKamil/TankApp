using MongoDB.Driver;
using TankBackend.Models;

namespace TankBackend.Data
{
    public class TankRepository : MongoRepository<TankModel>, ITankRepository
    {
        
        public TankRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "Tanks") { }
        public async Task<TankModel> GetByNameAsync(string name)
        {
            var collection = GetCollection();
            return await _collection.Find(tank => tank.TankName == name).FirstOrDefaultAsync();
        }
    }
}
