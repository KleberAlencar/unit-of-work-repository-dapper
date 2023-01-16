public interface IRepository<T> where T : class
{
    Task<T> Get(int id);
 
    Task<IReadOnlyList<T>> Search();
 
    Task<int> Add(T entity);
 
    Task<int> Update(T entity);
 
    Task<int> Delete(int id);
}