using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class ComicBookArtist
    {
        public int Id { get; set; }
        public ComicBook ComicBook { get; set; }
        public Artist Artist { get; set; }
        public string Type { get; set; }
    }
}
