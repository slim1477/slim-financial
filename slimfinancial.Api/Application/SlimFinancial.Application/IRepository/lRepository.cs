


namespace SlimFinancial.Application.IRepository;


/// <summary>
/// represents the application repository blueprint
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
     IEnumerable<T> GetAll();
     T GetById(int id);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}

