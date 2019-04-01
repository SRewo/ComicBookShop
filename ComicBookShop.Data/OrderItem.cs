using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class OrderItem : ValidableBase
    {
        public int Id { get; private set; }
        [Required]
        public virtual ComicBook ComicBook { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public double Price => (ComicBook.Price * Quantity * (1 - Discount * 0.01));

    }
}
