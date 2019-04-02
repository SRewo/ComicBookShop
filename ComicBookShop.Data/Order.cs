using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class Order : ValidableBase
    {
        public int Id { get; private set; }


        private DateTime _date;

        [Required]
        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date,value);
        }


        private ObservableCollection<OrderItem> _orderItems;

        [Required]
        public virtual ObservableCollection<OrderItem> OrderItems
        {
            get => _orderItems;
            set => SetProperty(ref _orderItems, value);
        }


        private Employee _employee;

        [Required]
        public virtual Employee Employee
        {
            get => _employee;
            set => SetProperty(ref _employee, value);
        }
    }
}
