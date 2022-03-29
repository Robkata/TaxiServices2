using ExpressTaxi.Abstractions;
using ExpressTaxi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Controllers
{
    public class TaxiController : Controller
    {
        private readonly ITaxiService _taxiService;

        public TaxiController(ITaxiService taxiService)
        {
            this._taxiService = taxiService;
        }


        public IActionResult Create()
        {
            return this.View();

        }

        [HttpPost]

        public IActionResult Create(TaxiCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {

                var created = _taxiService.Create(bindingModel.TaxiNumber, bindingModel.BrandId, bindingModel.Engine, bindingModel.Extras, bindingModel.Year, bindingModel.DriverId);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
