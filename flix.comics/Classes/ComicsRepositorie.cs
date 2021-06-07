using System.Collections.Generic;
using flix.comics.Interfaces;

namespace Classes
{
    public class ComicsRepositorie : IRepositories<Comics>
    {
        private List<Comics> comicsList = new List<Comics>();

        public List<Comics> ComicsList()
        {
            return this.comicsList;
        }

        public void Insert(Comics entity)
        {
            this.comicsList.Insert(this.NextId(), entity);
        }

        public void Update(int id, Comics entity)
        {
            this.comicsList[id] = entity;
        }
        public int NextId()
        {
            return this.comicsList.Count;
        }
        public Comics Exclude(int id)
        {
            Comics comics = this.comicsList[id];
            comics.Exclude();
            return comics;
        }

        public Comics ReturnById(int id)
        {
            return this.comicsList[id];
        }
    } 
}
