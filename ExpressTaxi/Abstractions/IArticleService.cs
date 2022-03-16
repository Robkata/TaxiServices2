using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Abstractions
{
    public interface IArticleService
    {
        bool Create(string article, string author, string picture, DateTime dateTime);
        bool UpdateArticle(int articleId, string article, string picture);
        List<Article> GetArticles();
        Article GetArticleById(int articleId);
        bool RemoveById(int articleId);
    }
}
