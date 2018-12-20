using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class ComicBook
    {
        public int Id { get; private set; }
        [Required]
        public string Title { get; set; }
        public DateTime OnSaleDate { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Series Series { get; set; }
    }
}
