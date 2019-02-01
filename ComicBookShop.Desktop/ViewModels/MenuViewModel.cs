using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ComicBookShop.Desktop.ViewModels
{
    public class MenuViewModel : BindableBase
    {

        private int _selectedOption;

        public int SelectedOption
        {
            get { return _selectedOption;}
            set { SetProperty(ref _selectedOption, value); }
        }

    }
}
