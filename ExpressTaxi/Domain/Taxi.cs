using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Domain
{
    public class Taxi
    {
        public int Id { get; set; }
        public string TaxiNumber { get; set; }
        public string BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public string Engine { get; set; }
        public string Extras { get; set; }
        public DateTime Year { get; set; }
      
        public string DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
