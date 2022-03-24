using ExpressTaxi.Abstractions;
using ExpressTaxi.Models.Option;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IOptionService _optionService;

        public ReservationController(IReservationService reservationService, IOptionService optionService)
        {
            _reservationService = reservationService;
            _optionService = optionService;
        }

        public ActionResult Reservate()
        {
            var reservation = new TaxiReservationVM();
            reservation.Options = _optionService.GetOptions()
                .Select(c => new OptionPairVM()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
                return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservate([FromForm] TaxiReservationVM reservation)
        {
            if(ModelState.IsValid)
            {
                var reservatedId = _reservationService.Reservate(reservation.Destination, reservation.Departure, reservation.Arrival, reservation.Passengers, reservation.OptionId);
                if(reservatedId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        // GET: ReservationController
        public ActionResult Index()
        {
            return View();
        }
    }
}
