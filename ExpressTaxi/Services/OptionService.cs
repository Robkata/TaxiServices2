using ExpressTaxi.Abstractions;
using ExpressTaxi.Data;
using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Services
{
    public class OptionService : IOptionService
    {
        private readonly ApplicationDbContext _context;

        public OptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Option GetOptionById(int optionId)
        {
            return _context.Options.Find(optionId);
        }

        public List<Option> GetOptions()
        {
            List<Option> options = _context.Options.ToList();
            return options;
        }

        public List<Reservation> GetReservationsByOption(int optionId)
        {
            return _context.Reservations.Where(x => x.OptionId == optionId).ToList();
        }
    }
}
