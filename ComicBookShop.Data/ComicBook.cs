using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class ComicBook : ValidableBase
    {
        public int Id { get; private set; }

        private string _title;

        [Required]
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title,value);
        }

        private DateTime _onSaleDate;

        public DateTime OnSaleDate
        {
            get => _onSaleDate;
            set => SetProperty(ref _onSaleDate, value);
        }

        private double _price;

        [Required]
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price,value);
        }

        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private Series _series;

        public virtual Series Series
        {
            get => _series;
            set => SetProperty(ref _series, value);
        }

        private ICollection<ComicBookArtist> _comicBookArtists;

        [Required]
        public ICollection<ComicBookArtist> ComicBookArtists
        {
            get => _comicBookArtists;
            set => SetProperty(ref _comicBookArtists,value);
        }

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
