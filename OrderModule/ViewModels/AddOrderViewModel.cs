using ComicBookShop.Data;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using ComicBookShop.Data.Repositories;
using Prism.Commands;

namespace OrderModule.ViewModels
{
    public class AddOrderViewModel : BindableBase, INavigationAware
    {
        private SqlRepository<Publisher> _publisherRepository;
        private SqlRepository<ComicBook> _comicBookRepository;

        public DelegateCommand AddItemCommand { get; set; }


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


        private List<ComicBook> _comicBooks;

        public List<ComicBook> ComicBooks
        {
            get => _comicBooks;
            set => SetProperty(ref _comicBooks, value);
        }


        private ComicBook _selectedComicBook;

        public ComicBook SelectedComicBook
        {
            get => _selectedComicBook;
            set => SetProperty(ref _selectedComicBook, value);
        }


        private Order _order;

        public Order Order
        {
            get => _order;
            set => SetProperty(ref _order, value);
        }


        public AddOrderViewModel()
        {
            AddItemCommand = new DelegateCommand(AddItem);
        }

        private void AddItem()
        {
            if (SelectedComicBook != null)
            {
                Order.OrderItems.Add(new OrderItem()
                {
                    ComicBook = SelectedComicBook,
                    Discount = 0,
                    Quantity = 1
                });
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return GlobalVariables.LoggedEmployee != null;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

            using (var context = new ShopDbEntities())
            {

                _publisherRepository = new SqlRepository<Publisher>(context);
                Publishers = _publisherRepository.GetAll().ToList();

                _comicBookRepository =new SqlRepository<ComicBook>(context);
                ComicBooks = _comicBookRepository.GetAll().Include(x => x.Series).Include(x => x.Series.Publisher).Include(x => x.ComicBookArtists.Select(y => y.Artist))
                    .ToList();

            }

            Order = new Order()
            {
                Employee = GlobalVariables.LoggedEmployee,
                OrderItems = new ObservableCollection<OrderItem>()
            };

        }
    }
}
