namespace WebApplicationDemo.Repositories.Interfaces
{
    public interface IUsuarioRepository<T> where T : class
    {
        List<T> Get();

        T GetByID(int usuariosId);
        void Insert(T usuario);
        void Delete(T usuario);
        T Update(T usuario);
        void Save();

    }
}