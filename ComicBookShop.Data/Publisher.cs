using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Data
{
    public class Publisher : NotifyDataErrorModel
    {
        
        public int Id { get; private set; }

        private string _name;
        [Required] 
        public string Name {
            get => _name; 
            set => SetProperty(ref _name, value); 
        }
        public string Description { get; set; }

        private DateTime _creationDateTime;

        [CustomDateAttribute]
        public DateTime CreationDateTime
        {
            get => _creationDateTime;
            set => SetProperty(ref _creationDateTime, value);
        }


    }

    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute()
            : base(typeof(DateTime),
                DateTime.Now.AddYears(-119).ToShortDateString(),
                DateTime.Now.AddDays(1).ToShortDateString())
        { }
    }
}
