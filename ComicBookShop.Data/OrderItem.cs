using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class OrderItem
    {
        public int Id { get; set; }
        public ComicBook ComicBook { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

    }
}
