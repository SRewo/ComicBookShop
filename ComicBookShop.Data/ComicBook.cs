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
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public virtual Series Series { get; set; }
        [Required]
        public ICollection<ComicBookArtist> ComicBookArtists { get; set; }

        public string ShortArtistDetail => GetShortArtistDetail();


        private string GetShortArtistDetail()
        {

            int n = ComicBookArtists.Count();
            string result = string.Empty;
            foreach (var artist in ComicBookArtists)
            {
                result += n == 1 ? artist.Artist.Name : artist.Artist.Name + ", ";
                n--;
            }

            return result;
        }
    }
}
