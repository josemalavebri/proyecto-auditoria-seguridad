
public abstract class BaseRepositorio<T> : IBaseRepositorio<T>
{
    protected RepositorioDatos accesoDatos;

    public BaseRepositorio()
    {
        this.accesoDatos = RepositorioDatos.Instancia;
    }

    public abstract List<T> Get();
    public abstract bool Post(T entity);
    public abstract bool Put(int id);
    public abstract bool Update(T entity);
}