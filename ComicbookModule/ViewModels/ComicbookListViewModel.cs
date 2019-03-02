using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ComicBookShop.Data;
using ComicBookShop.Data.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace ComicBookModule.ViewModels
{
    public class ComicBookListViewModel : BindableBase, INavigationAware
    {
        private readonly IRepository<ComicBook> _comicBookRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly List<ComicBook> _allComicBooks;
        public DelegateCommand SelectedPublisherChanged { get; private set; }
        public DelegateCommand SearchWordChanged { get; private set; }
        public DelegateCommand ResetSearchCommand { get; private set; }

        private List<ComicBook> _viewList;

        public List<ComicBook> ViewList
        {
            get => _viewList;
            set => SetProperty(ref _viewList, value);
        }

        private List<Publisher> _publishers;

        public List<Publisher> Publishers
        {
            get => _publishers;
            set => SetProperty(ref _publishers, value);
        }

        private Publisher _selectedPublisher;

        public Publisher SelectedPublisher
        {
            get => _selectedPublisher;
            set => SetProperty(ref _selectedPublisher, value);
        }

        private string _searchWord;

        public string SearchWord
        {
            get => _searchWord;
            set => SetProperty(ref _searchWord, value);
        }



        public ComicBookListViewModel()
        {

            using (var context = new ShopDbEntities())
            {
                
                _comicBookRepository = new SqlRepository<ComicBook>(context);
                _allComicBooks = _comicBookRepository.GetAll().Include(x => x.ComicBookArtists).Include(x => x.Series).Include(x => x.Series.Publisher).Include(x => x.ComicBookArtists.Select(z => z.Artist)).ToList();

                _publisherRepository = new SqlRepository<Publisher>(context);
                _publishers = _publisherRepository.GetAll().ToList();

            }

            SelectedPublisherChanged = new DelegateCommand(PublisherChanged);
            SearchWordChanged = new DelegateCommand(Search);
            ResetSearchCommand = new DelegateCommand(ResetSearch);
            ViewList = _allComicBooks;

        }

        private void PublisherChanged()
        {

            if (string.IsNullOrEmpty(SearchWord))
            {
                ViewList = _allComicBooks.Where(x => x.Series.Publisher.Equals(SelectedPublisher)).ToList();
            }
            else
            {
                ViewList = _allComicBooks.Where(x =>
                    x.Series.Publisher.Equals(SelectedPublisher) && ( CheckStringEquals(x.Title,SearchWord) || CheckStringEquals(x.Series.Name,SearchWord)|| x.ComicBookArtists.Any(z => CheckStringEquals(z.Artist.Name,SearchWord)))).ToList();
            }

        }

        private void Search()
        {

            if (SelectedPublisher == null)
            {
                ViewList = _allComicBooks.Where(x =>
                    CheckStringEquals(x.Title, SearchWord) || CheckStringEquals(x.Series.Name, SearchWord) || x.ComicBookArtists.Any(z => CheckStringEquals(z.Artist.Name, SearchWord))).ToList();
            }
            else
            {
                ViewList = _allComicBooks.Where(x =>
                    x.Series.Publisher.Equals(SelectedPublisher) && (CheckStringEquals(x.Title, SearchWord) || CheckStringEquals(x.Series.Name, SearchWord) || x.ComicBookArtists.Any(z => CheckStringEquals(z.Artist.Name, SearchWord)))).ToList();
            }

        }

        private void ResetSearch()
        {

            SearchWord = String.Empty;
            SelectedPublisher = null;
            ViewList = _allComicBooks.ToList();

        }

        private bool CheckStringEquals(string first, string second)
        {
            return first.IndexOf(second, StringComparison.OrdinalIgnoreCase) != -1;
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
