using MongoDB.Driver;
using System.Linq.Expressions;

namespace TankBackend.Data;

public interface IMongorepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync(); 
    Task<List<T>> FindAsync(Expression<Func<T, bool>> filter);
    Task AddAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}
