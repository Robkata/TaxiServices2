using ExpressTaxi.Abstractions;
using ExpressTaxi.Data;
using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Services
{
    public class ReservationService: IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Option GetOptionById(int optionId)
        {
            throw new NotImplementedException();
        }

        public List<Option> GetOptions()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int optionId)
        {
            throw new NotImplementedException();
        }

        public bool Reservate(string destination, DateTime departure, DateTime arrival, int passengers, int optionId)
        {
            var reservation = new Reservation
            {
                Destination = destination,
                Departure = departure,
                Arrival = arrival,
                Passengers = passengers,
                Option = _context.Options.Find(optionId)
            };
            _context.Reservations.Add(reservation);
            return _context.SaveChanges() != 0;
        }

        public bool Reservate(string destination, DateTime departure, DateTime arrival, int passengers, string name, int optionId)
        {
            throw new NotImplementedException();
        }
    }
}
