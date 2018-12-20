using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class Series
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Publisher Publisher { get; set; }
        public string Description { get; set; }
    }
}
