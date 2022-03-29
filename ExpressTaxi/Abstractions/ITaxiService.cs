using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Abstractions
{
    public interface ITaxiService
    {
        bool Create(string taxiNumber, string brandId, string engine, string extras, DateTime year, string driverId);
        bool UpdateTaxi(int taxiId, string taxiNumber, string brand, string engine, string extras);
        List<Taxi> GetTaxies();
        Taxi GetTaxiById(int taxiId);
        bool RemoveById(int taxiId);
        List<Taxi> GetTaxies(string searchStringTaxi, string searchStringDriver);
    }
}
