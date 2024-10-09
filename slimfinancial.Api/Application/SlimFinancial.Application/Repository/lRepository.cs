


namespace SlimFinancial.Application.Repository;


/// <summary>
/// represents the application repository blueprint
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
     Task<IEnumerable<T>> GetAll();
     Task<T> GetByIdAsync(string id);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}

