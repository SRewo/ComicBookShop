using System.Collections.Generic;
using System.Linq;
using ComicBookShop.Data;
using ComicBookShop.Data.Repositories;
using Prism.Commands;
using Prism.Mvvm;

namespace EmployeeModule.ViewModels
{
    public class EmployeeListViewModel : BindableBase
    {
        private List<Employee> _employeeList;
        private readonly SqlRepository<Employee> _employeeRepository;

        public EmployeeListViewModel()
        {
            using (var datacontext = new ShopDbEntities())
            {
                _employeeRepository = new SqlRepository<Employee>(datacontext);
                var query = from employee in _employeeRepository.GetAll().AsEnumerable() select employee;
                EmployeeList = query.ToList();
            }
        }

        public List<Employee> EmployeeList
        {
            get => _employeeList;
            set => SetProperty(ref _employeeList, value);
        }

        public DelegateCommand UserControlLoaded { get; private set; }
    }
}