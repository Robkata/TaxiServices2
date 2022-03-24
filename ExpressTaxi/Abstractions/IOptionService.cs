using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Abstractions
{
    public interface IOptionService
    {
        List<Option> GetOptions();
        Option GetOptionById(int optionId);
        List<Reservation> GetReservationsByOption(int optionId);
    }
}
