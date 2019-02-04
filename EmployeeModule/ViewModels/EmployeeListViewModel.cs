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

namespace EmployeeModule.ViewModels
{
    public class EmployeeListViewModel : BindableBase
    {

        private List<Employee> _employeeList;

        public List<Employee> EmployeeList
        {
            get { return _employeeList; }
            set { SetProperty(ref _employeeList, value); }
        }

        private SqlRepository<Employee> _employeeRepository;

        public DelegateCommand UserControlLoaded { get; private set; }

        public EmployeeListViewModel()
        {
            using (var datacontext = new ShopDbEntities())
            {

                _employeeRepository = new SqlRepository<Employee>(datacontext);
                var query = from employee in _employeeRepository.GetAll().AsEnumerable() select employee;
                EmployeeList = query.ToList();

            }
            
        }
    }
}
