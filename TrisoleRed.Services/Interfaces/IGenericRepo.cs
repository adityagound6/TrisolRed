using System.Linq;
namespace TrisoleRed.Services.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    
}
