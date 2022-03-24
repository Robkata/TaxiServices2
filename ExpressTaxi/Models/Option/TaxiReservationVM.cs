using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Models.Option
{
    public class TaxiReservationVM
    {
        public TaxiReservationVM()
        {
            Options = new List<OptionPairVM>();
        }
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public DateTime Arrival { get; set; }

        [MinLength(1)]
        [Required]
        public int Passengers { get; set; }

        [Display(Name = "Option")]
        public int OptionId { get; set; }
        public virtual List<OptionPairVM> Options { get; set; }
    }
}
