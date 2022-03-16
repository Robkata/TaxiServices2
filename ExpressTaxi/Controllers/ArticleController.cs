using ExpressTaxi.Abstractions;
using ExpressTaxi.Data;
using ExpressTaxi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articlesService)
        {
            this._articleService = articlesService;
        }
        // GET: AdminController
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return this.View();

        }

        [HttpPost]
        public IActionResult Create(ArticleCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _articleService.Create(bindingModel.Article, bindingModel.Author, bindingModel.Picture, bindingModel.DateTime);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult All(string searchStringBreed, string searchStringName)
        {

            List<ArticleAllViewModel> articles = _articleService.GetArticles()
                .Select(articleFromDb => new ArticleAllViewModel
                {
                    Id = articleFromDb.Id,
                    Article = articleFromDb.Article,
                    Author = articleFromDb.Author,
                    Picture = articleFromDb.Picture,
                    DateTime = articleFromDb.DateTime

                }).ToList();
            return this.View(articles);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
