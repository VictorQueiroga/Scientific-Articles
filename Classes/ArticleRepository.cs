using System;
using System.Collections.Generic;
using ScientificArticles.Interfaces;

namespace ScientificArticles
{
    public class ArticleRepository : IRepository<Article>
    {
        private List<Article> listArticle = new List<Article>();
        public void Delete(int Id)
        {
            listArticle[Id].Deleted();
        }

        public void Insert(Article Entity)
        {
            listArticle.Add(Entity);
        }

        public List<Article> List()
        {
            return listArticle;
        }

        public int NextId()
        {
            return listArticle.Count;
        }

        public Article ReturnById(int Id)
        {
            return listArticle[Id];
        }

        public void Update(int Id, Article Entity)
        {
            listArticle[Id] = Entity;
        }
    }
}
