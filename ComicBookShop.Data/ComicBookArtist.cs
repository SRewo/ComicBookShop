using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class ComicBookArtist : ValidableBase
    {
        public int Id { get; private set; }

        private Artist _artist;

        [Required]
        public Artist Artist
        {
            get => _artist;
            set => SetProperty(ref _artist,value);
        }

        private string _type;

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type,value);
        }
    }
}
