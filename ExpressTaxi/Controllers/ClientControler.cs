using ExpressTaxi.Data;
using ExpressTaxi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext context;

        public ClientController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: ClientControler

        public ActionResult AllClients()
        {
            List<ClientBindingAllViewModel> users = context.Users
            .Select(
             clients => new ClientBindingAllViewModel
             {
                 Id = clients.Id,
                 UserName = clients.UserName,
                 FirstName = clients.FirstName,
                 LastName = clients.LastName,
                 Email = clients.Email,
                 PhoneNumber = clients.PhoneNumber
             }).ToList();
            return View(users);
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientControler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ClientControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientControler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ClientControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
