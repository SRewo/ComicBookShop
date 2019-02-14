using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookShop.Data;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ComicbookModule.ViewModels
{
    public class AddEditArtistViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private IRepository<Artist> _artistRepository;
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand FirstNameChangedCommand { get; private set; }
        public DelegateCommand LastNameChangedCommand { get; private set; }

        private Artist _artist;

        public Artist Artist
        {
            get => _artist;
            set => SetProperty(ref _artist, value);
        }

        public AddEditArtistViewModel(IRegionManager manager)
        {

            _regionManager = manager;
            GoBackCommand = new DelegateCommand(GoBack);

        }

        private void GoBack()
        {
            
            _regionManager.RequestNavigate("content","ArtistList");

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Artist = new Artist();
        }
    }
}
