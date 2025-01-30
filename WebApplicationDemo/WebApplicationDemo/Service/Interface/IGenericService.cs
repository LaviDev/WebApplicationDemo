namespace WebApplicationDemo.Service.Interface
{
    public interface IGenericService<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Add(T obj);
        public void Update(T obj);
        public void Delete(int id);
    }
}
