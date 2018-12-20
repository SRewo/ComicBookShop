using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class ComicBookArtist
    {
        public int Id { get; set; }
        [Required]
        public ComicBook ComicBook { get; set; }
        [Required]
        public Artist Artist { get; set; }
        public string Type { get; set; }
    }
}
