using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

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

        private RegionManager _regionManager;

        

        public MenuViewModel(RegionManager manager)
        {

            _regionManager = manager;

        }

        
    }
}
