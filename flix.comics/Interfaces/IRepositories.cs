using System.Collections.Generic;

namespace flix.comics.Interfaces
{
    public interface IRepositories<T>
    {
        List<T> ComicsList();
        T ReturnById(int id);
        void Insert(T entity);
        T Exclude(int id);
        void Update(int id, T entity);
        int NextId();
    }
}
