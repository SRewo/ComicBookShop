using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ComicBookShop.Data;
using ComicBookShop.Data.Repositories;
using Prism.Commands;
using Prism.Mvvm;


namespace ComicbookModule.ViewModels
{
    public class SeriesListViewModel : BindableBase
    {
        private List<Series> _allSeries;
        private IRepository<Series> _seriesRepository;
        private IRepository<Publisher> _publisherRepository;
        public DelegateCommand EditSeriesCommand { get; set; }
        public DelegateCommand AddSeriesCommand { get; set; }
        public DelegateCommand SearchWordChanged { get; set; }
        public DelegateCommand SelectedPublisherChanged { get; set; }
        public DelegateCommand ResetSearchCommand { get; set; }


        private string _searchWord;

        public string SearchWord
        {
            get => _searchWord;
            set => SetProperty(ref _searchWord, value);
        }

        private List<Series> _viewList;

        public List<Series> ViewList
        {
            get => _viewList;
            set => SetProperty(ref _viewList, value);
        }

        private Series _selectedSeries;

        public Series SelectedSeries
        {
            get => _selectedSeries;
            set => SetProperty(ref _selectedSeries, value);
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

        public SeriesListViewModel()
        {

            using (var context = new ShopDbEntities())
            {
             
                _seriesRepository = new SqlRepository<Series>(context);
                _allSeries = _seriesRepository.GetAll().Include(m => m.Publisher).ToList();
                ViewList = _allSeries;
                
                _publisherRepository = new SqlRepository<Publisher>(context);
                _publishers = _publisherRepository.GetAll().ToList();

            }

            SearchWordChanged = new DelegateCommand(SearchByWord);
            SelectedPublisherChanged = new DelegateCommand(SearchByPublisher);
            ResetSearchCommand = new DelegateCommand(ResetSearch);

        }

        private void SearchByWord()
        {
            if (SelectedPublisher == null)
            {
                var series = _allSeries.Where(c => c.Name.ToLower().Contains(SearchWord.Trim().ToLower()));

                ViewList = series.ToList();
            }
            else
            {
                var series = _allSeries.Where(c => c.Name.ToLower().Contains(SearchWord.Trim().ToLower()) && c.Publisher.Id.Equals(SelectedPublisher.Id));

                ViewList = series.ToList();
            }

        }

        private void SearchByPublisher()
        {

            if (string.IsNullOrEmpty(SearchWord) && SelectedPublisher != null)
            {

                var series = _allSeries.Where(c => c.Publisher.Id.Equals(SelectedPublisher.Id));

                ViewList = series.ToList();

            }
            else if(SelectedPublisher != null)
            {

                var series = _allSeries.Where(c => c.Name.ToLower().Contains(SearchWord.Trim().ToLower()) && c.Publisher.Id.Equals(SelectedPublisher.Id));

                ViewList = series.ToList();

            }

        }

        private void ResetSearch()
        {

            SearchWord = string.Empty;
            SelectedPublisher = null;
            ViewList = _allSeries.ToList();

        }

    }
}
