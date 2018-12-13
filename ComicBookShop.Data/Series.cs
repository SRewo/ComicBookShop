using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Publisher Publisher { get; set; }
        public string Description { get; set; }
    }
}
