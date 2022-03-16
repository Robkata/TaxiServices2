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

        public bool Create(string articleName, string author, string picture, DateTime dateTime)
        {
            Article item = new Article
            {
                ArticleName = articleName,
                Author = author,
                Picture = picture,
                DateTime = dateTime
            };
            _context.Articles.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Article GetArticleById(int articleId)
        {
            return _context.Articles.Find(articleId);
        }

        public List<Article> GetArticles()
        {
            List<Article> articles = _context.Articles.ToList();
            return articles;
        }

        public List<Article> GetArticles(string searchStringArticle, string searchStringAuthor)
        {
            List<Article> articles = _context.Articles.ToList();
            if (!String.IsNullOrEmpty(searchStringArticle) && !String.IsNullOrEmpty(searchStringAuthor))
            {
                articles = articles.Where(d => d.ArticleName.Contains(searchStringArticle) && d.Author.Contains(searchStringAuthor)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringArticle))
            {
                articles = articles.Where(d => d.ArticleName.Contains(searchStringArticle)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringAuthor))
            {
                articles = articles.Where(d => d.Author.Contains(searchStringAuthor)).ToList();
            }
            return articles;
        }

        public bool RemoveById(int articleId)
        {
            var article = GetArticleById(articleId);
            if (article == default(Article))
            {
                return false;
            }
            _context.Remove(article);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateArticle(int articleId, string articleName, string picture)
        {
            var item = GetArticleById(articleId);
            if (item == default(Article))
            {
                return false;
            }
            item.ArticleName = articleName;
            item.Picture = picture;
            _context.Update(item);
            return _context.SaveChanges() != 0;
        }
    }
}
