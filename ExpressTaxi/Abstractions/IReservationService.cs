using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Abstractions
{
    public interface IReservationService
    {
        bool Reservate(string destination, DateTime departure, DateTime arrival, int passengers, int optionId);
        List<Option> GetOptions();
        Option GetOptionById(int optionId);
        bool RemoveById(int optionId);
    }
}
