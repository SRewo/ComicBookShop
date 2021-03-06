﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class Series : ValidableBase
    {
        public int Id { get; private set; }
        private string _name;

        [Required]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name,value);
        }

        private Publisher _publisher;

        [Required]
        public virtual Publisher Publisher
        {
            get => _publisher;
            set => SetProperty(ref _publisher,value);
        }

        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
