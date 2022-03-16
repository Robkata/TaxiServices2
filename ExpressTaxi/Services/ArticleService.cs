using ExpressTaxi.Abstractions;
using ExpressTaxi.Data;
using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Services
{
    public class ArticleService: IArticleService
    {
        private readonly ApplicationDbContext _context;

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string article, string author, string picture, DateTime dateTime)
        {
            Article item = new Article
            {
                Article = article,
                Author = author,
                Picture = picture,
                DateTime = dateTime
            };
            _context.Articles.Add(item);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateArticle(int articleId, string article, string picture)
        {
            var item = GetArticleById(articleId);
            if(item == default(Article))
            {
                return false;
            }
            item.Article = article;
            item.Picture = picture;
            _context.Update(item);
            return _context.SaveChanges() != 0;
        }

        public Article GetArti
    }
}
