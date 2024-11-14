


namespace SlimFinancial.Application.Repository;


/// <summary>
/// represents the application repository blueprint
/// </summary>
/// <typeparam name="T">where 'T' is type</typeparam>
    public interface IRepository<T>
    {
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> CreateAsync(T entity);
    void Update(T entity);
    Task<int> Close(T entity);
}

