using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Domain
{
    public class Reservation
    {
        public Reservation()
        {
            this.Status = "Submitted";
        }
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int Passengers { get; set; }
        public int OptionId { get; set; }
        public virtual Option Option { get; set; }
        public string Status { get; set; }
    }
}
