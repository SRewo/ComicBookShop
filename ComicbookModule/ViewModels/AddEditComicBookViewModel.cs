﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ComicBookShop.Data;
using ComicBookShop.Data.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ComicBookModule.ViewModels
{
    class AddEditComicBookViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private readonly IRepository<ComicBook> _comicBookRepository;
        private readonly IRepository<Artist> _artistRepository;
        private readonly IRepository<Series> _seriesRepository;

        public DelegateCommand AddArtistCommand { get; set; }
        public DelegateCommand RemoveArtistCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        private ComicBook _comicBook;

        public ComicBook ComicBook
        {
            get => _comicBook;
            set => SetProperty(ref _comicBook, value);
        }

        private List<Artist> _artists;

        public List<Artist> Artists
        {
            get => _artists;
            set => SetProperty(ref _artists, value);
        }

        private Artist _selectedArtist;

        public Artist SelectedArtist
        {
            get => _selectedArtist;
            set => SetProperty(ref _selectedArtist, value);
        }

        private ComicBookArtist _selectedComicBookArtist;
        
        public ComicBookArtist SelectedComicBookArtist
        {
            get => _selectedComicBookArtist;
            set => SetProperty(ref _selectedComicBookArtist, value);
        }

        private List<Series> _seriesList;

        public List<Series> SeriesList
        {
            get => _seriesList;
            set => SetProperty(ref _seriesList, value);
        }

        private bool _canSave;

        public bool CanSave
        {
            get => _canSave;
            set => SetProperty(ref _canSave, value);
        }



        public AddEditComicBookViewModel(IRegionManager manager)
        {

            _regionManager = manager;

            using (var context = new ShopDbEntities())
            {
                
                _artistRepository = new SqlRepository<Artist>(context);
                Artists = _artistRepository.GetAll().ToList();

                _seriesRepository = new SqlRepository<Series>(context);
                SeriesList = _seriesRepository.GetAll().ToList();

            }

            AddArtistCommand = new DelegateCommand(AddArtist);
            RemoveArtistCommand = new DelegateCommand(RemoveArtist);
            GoBackCommand = new DelegateCommand(GoBack);



            ComicBook = new ComicBook()
            {
                OnSaleDate = DateTime.Now
            };
            if(ComicBook.ComicBookArtists == null)
                ComicBook.ComicBookArtists = new ObservableCollection<ComicBookArtist>();

            CanSave = false;
            ComicBook.PropertyChanged += ComicBook_PropertyChanged;
        }

        private void ComicBook_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (ComicBook.Title != String.Empty && ComicBook.Price > 0 && ComicBook.Series != null && ComicBook.ComicBookArtists.Count() != 0)
                CanSave = !ComicBook.HasErrors;
            else
                CanSave = false;

        }

        private void AddArtist()
        {

            if ( SelectedArtist != null && !ComicBook.ComicBookArtists.Any(x => x.Artist.Equals(SelectedArtist)) )
            {

                ComicBook.ComicBookArtists.Add(new ComicBookArtist()
                {
                    Artist = SelectedArtist,
                    Type = String.Empty
                });

                ComicBook_PropertyChanged(null, null);

            }
            
        }

        private void RemoveArtist()
        {
            if (SelectedArtist != null)
            {

                ComicBook.ComicBookArtists.Remove(SelectedComicBookArtist);
                ComicBook_PropertyChanged(null, null);

            }
        }

        private void GoBack()
        {

            _regionManager.RequestNavigate("content","ComicBookList");

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
