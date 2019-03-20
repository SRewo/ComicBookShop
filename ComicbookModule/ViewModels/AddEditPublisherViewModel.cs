using System;
using ComicBookShop.Data;
using ComicBookShop.Data.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ComicBookModule.ViewModels
{
    public class AddEditPublisherViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand SavePublisherCommand { get; set; }
        public DelegateCommand NameChangedCommand { get; set; }
        public DelegateCommand DateChangedCommand { get; set; }

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

        private string _nameErrorMessage;

        public string NameErrorMessage
        {
            get => _nameErrorMessage;
            set => SetProperty(ref _nameErrorMessage, value);
        }

        private string _dateErrorMessage;

        public string DateErrorMessage
        {
            get => _dateErrorMessage;
            set => SetProperty(ref _dateErrorMessage, value);
        }

        public AddEditPublisherViewModel(IRegionManager manager)
        {

            _regionManager = manager;
            GoBackCommand = new DelegateCommand(GoBack);
            SavePublisherCommand = new DelegateCommand(SavePublisher);
            NameChangedCommand = new DelegateCommand(CheckNameErrors);
            DateChangedCommand = new DelegateCommand(CheckDateErrors);

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

            Publisher.PropertyChanged += CanExecuteChanged;
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {

            if(!string.IsNullOrEmpty(Publisher.Name))
                CanSave = !Publisher.HasErrors;
            else
                CanSave = false;

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
                    _publisherRepository.AddOrUpdate(Publisher);
                    context.SaveChanges();

                }

                _regionManager.RequestNavigate("content", "PublisherList");

            }

        }

        private void CheckNameErrors()
        {
            if (Publisher == null)
            {

                NameErrorMessage = string.Empty;

            }
            else if (Publisher.HasErrors == true && Publisher.GetErrors("Name") != null)
            {
                NameErrorMessage = Publisher.GetFirstError("Name");
            }
            else
            {
                NameErrorMessage = string.Empty;
            }
        }

        private void CheckDateErrors()
        {
            if (Publisher == null)
            {
                DateErrorMessage = string.Empty;

            }
            else if (Publisher.HasErrors == true && Publisher.GetErrors("CreationDateTime") != null)
            {
                DateErrorMessage = Publisher.GetFirstError("CreationDateTime");
            }
            else
            {
                DateErrorMessage = string.Empty;
            }
        }
    }
}
