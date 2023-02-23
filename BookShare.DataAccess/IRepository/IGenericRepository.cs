
using BookShare.Domain.Commons;
using System.Buffers.Text;

namespace BookShare.DataAccess.IRepository;

public interface IGenericRepository<TEntity>
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(long Id, TEntity entity);
    Task<bool> DeleteAsync(long Id);
    Task<TEntity> GetByIdAsync(long id);
    Task<List<TEntity>> GetAllAsync();
}
