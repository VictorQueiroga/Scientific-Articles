using System.Collections.Generic;
namespace ScientificArticles.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();

        T ReturnById(int Id);

        void Insert(T Entity);

        void Delete(int Id);

        void Update(int Id, T Entity);

        int NextId();
    }
}
