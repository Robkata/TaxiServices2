using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressTaxi.Models
{
    public class ArticleCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [Range(50, 200, ErrorMessage = "Статията трябва да е дълга между 50 и 200 символа!")]
        public string ArticleName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Името на автора на статията тук")]
        public string Author { get; set; }

        [Display(Name = "Снимка към статията(не е задължително)")]
        public string Picture { get; set; }
        public DateTime DateTime { get; set; }
    }
}
