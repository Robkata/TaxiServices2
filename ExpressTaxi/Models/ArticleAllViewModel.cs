using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Models
{
    public class ArticleAllViewModel
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Author { get; set; }
        public string Picture { get; set; }
        public DateTime DateTime { get; set; }
    }
}
