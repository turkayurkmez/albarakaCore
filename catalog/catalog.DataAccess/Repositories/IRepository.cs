using catalog.Entities;

namespace catalog.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);

        Task<bool> IsEntityExists(int id);



    }
}
