


namespace SlimFinancial.Application.Repository;


/// <summary>
/// represents the application repository blueprint
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task<int> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    void Delete(T entity);
}

