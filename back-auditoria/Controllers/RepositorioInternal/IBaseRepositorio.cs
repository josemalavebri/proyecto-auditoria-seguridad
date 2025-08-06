public interface IBaseRepositorio<T>
{
    List<T> Get();
    bool Post(T entity);
    bool Update(T entity);
    bool Put(int id);
}