using ExpressTaxi.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Models
{
    public class TaxiCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string TaxiNumber { get; set; }

        [Required]
        [Display(Name = "Your car's brand here")]
        public string BrandId { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public string Extras { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public string DriverId { get; set; }
    }
}
