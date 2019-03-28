using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class Order : ValidableBase
    {
        public int Id { get; private set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual List<OrderItem> OrderItems { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
    }
}
