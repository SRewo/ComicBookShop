using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ComicBookShop.Data;
using ComicBookShop.Data.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ComicbookModule.ViewModels
{
    public class ArtistListViewModel : BindableBase, INavigationAware
    {

        private IRepository<Artist> _artistRepository;
        private List<Artist> _allArtists;
        private IRegionManager _regionManager;
        public DelegateCommand AddArtistCommand { get; private set; }
        public DelegateCommand EditArtistCommand { get; private set; }

        private List<Artist> _viewList;

        public List<Artist> ViewList
        {
            get => _viewList;
            set => SetProperty(ref _viewList, value);
        }

        private string _searchWord;

        public string SearchWord
        {
            get => _searchWord;
            set => SetProperty(ref _searchWord, value);
        }

        private Artist _artist;

        public Artist Artist
        {
            get => _artist;
            set => SetProperty(ref _artist, value);
        }

        public ArtistListViewModel(IRegionManager manager)
        {

            _regionManager = manager;
            AddArtistCommand = new DelegateCommand(OpenAdd);
            EditArtistCommand = new DelegateCommand(OpenEdit);

            using (var context = new ShopDbEntities())
            {
                
                _artistRepository = new SqlRepository<Artist>(context);
                _allArtists = _artistRepository.GetAll().ToList();
                ViewList = _allArtists;

            }

        }

        private void OpenAdd()
        {
            
            _regionManager.RequestNavigate("content","AddEditArtist");

        }

        private void OpenEdit()
        {
            if (Artist == null)
                MessageBox.Show("You have to choose artist.");
            else
            {
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add("Artist",Artist);
                _regionManager.RequestNavigate("content","AddEditArtist",parameters);
            }
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

        }
    }
}
