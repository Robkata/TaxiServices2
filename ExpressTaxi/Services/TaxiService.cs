using ExpressTaxi.Abstractions;
using ExpressTaxi.Data;
using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Services
{
    public class TaxiService: ITaxiService
    {
        private readonly ApplicationDbContext _context;

        public TaxiService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string taxiNumber, string brandId, string engine, string extras, DateTime year, string driverId)
        {
            Taxi item = new Taxi
            {
                TaxiNumber = taxiNumber,
                BrandId = brandId,
                Engine = engine,
                Extras = extras,
                Year = year,
                DriverId = driverId
            };

            _context.Taxies.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Taxi GetTaxiById(int taxiId)
        {
            return _context.Taxies.Find(taxiId);
        }

        public List<Taxi> GetTaxies()
        {
            List<Taxi> taxies = _context.Taxies.ToList();
            return taxies;
        }

        public List<Taxi> GetTaxies(string searchStringTaxi, string searchStringDriver)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int taxiId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTaxi(int taxiId, string taxiNumber, string brand, string engine, string extras)
        {
            throw new NotImplementedException();
        }
    }
}
