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
    public class AddEditPublisherViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand SavePublisherCommand { get; set; }

        private bool _canSave;

        public bool CanSave
        {
            get => _canSave;
            set => SetProperty(ref _canSave, value);
        }

        private SqlRepository<Publisher> _publisherRepository;

        private Publisher _publisher;

        public Publisher Publisher
        {
            get => _publisher;
            set => SetProperty(ref _publisher, value);
        }

        public AddEditPublisherViewModel(IRegionManager manager)
        {

            _regionManager = manager;
            GoBackCommand = new DelegateCommand(GoBack);
            SavePublisherCommand = new DelegateCommand(SavePublisher);

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

            Publisher = null;
            Publisher = (Publisher) navigationContext.Parameters["publisher"];
            if (Publisher == null)
            {
                CanSave = false;
                Publisher = new Publisher()
                {
                    CreationDateTime = DateTime.Now
                };

            }
            else
            {
                CanSave = true;
            }

            Publisher.ErrorsChanged += CanExecuteChanged;
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {

            CanSave = !Publisher.HasErrors;

        }

        private void GoBack()
        {
            _regionManager.RequestNavigate("content","PublisherList");
        }

        private void SavePublisher()
        {
            if (Publisher != null)
            {
                using (var context = new ShopDbEntities())
                {

                    _publisherRepository = new SqlRepository<Publisher>(context);
                    _publisherRepository.Update(Publisher);
                    context.SaveChanges();

                }

                _regionManager.RequestNavigate("content", "PublisherList");

            }

        }
    }
}
