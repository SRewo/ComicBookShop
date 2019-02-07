using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ComicBookShop.Data;
using ComicBookShop.Data.Repositories;
using Prism.Commands;
using Prism.Mvvm;

namespace ComicbookModule.ViewModels
{
    public class PublishersListViewModel : BindableBase
    {
        private List<Publisher> _allPublishers;
        private SqlRepository<Publisher> _publisherRepository;

        private string _searchWord;
        private List<Publisher> _viewList;
        private Publisher _selectedPublisher;

        public string SearchWord
        {
            get => _searchWord;
            set => SetProperty(ref _searchWord, value);
        }

        public List<Publisher> ViewList
        {
            get => _viewList;
            set => SetProperty(ref _viewList, value);
        }

        public Publisher SelectedPublisher
        {
            get => _selectedPublisher;
            set => SetProperty(ref _selectedPublisher, value);
        }

        public DelegateCommand SearchWordChanged { get; set; }
        public DelegateCommand AddPublisherCommand { get; set; }
        public DelegateCommand EditPublisherCommand { get; set; }

        public PublishersListViewModel()
        {
            using (var datacontext = new ShopDbEntities())
            {

                _publisherRepository = new SqlRepository<Publisher>(datacontext);
                _allPublishers = _publisherRepository.GetAll().ToList();
                ViewList = _allPublishers;

                SearchWordChanged = new DelegateCommand(Search);
                EditPublisherCommand = new DelegateCommand(OpenEdit);
                AddPublisherCommand = new DelegateCommand(OpenAdd);

            }
        }

        private void Search()
        {

            if (string.IsNullOrEmpty(_searchWord))
            {

                ViewList = _allPublishers;

            }
            else
            {

                var query = from publisher in _allPublishers
                    where publisher.Name.ToLower().Contains(_searchWord.ToLower())
                            select publisher;
                ViewList = query.ToList();

            }
        }

        private void OpenEdit()
        {

            if (_selectedPublisher == null)
            {

                MessageBox.Show("You have to choose publisher.");

            }
            else
            {

                MessageBox.Show(_selectedPublisher.Name);

            }
        }

        private void OpenAdd()
        {

        }
    }
}