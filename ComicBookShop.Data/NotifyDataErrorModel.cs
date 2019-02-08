using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ComicBookShop.Data
{
    public class NotifyDataErrorModel : BindableBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _propErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => (_propErrors.Count() > 0);

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate{};

        public IEnumerable GetErrors(string propertyName)
        {
            
            if (_propErrors.ContainsKey(propertyName))
            {
                return _propErrors[propertyName];
            }
            else
            {
                return null;
            }

        }

        protected override bool SetProperty<T>(ref T member, T val,
            [CallerMemberName] string propertyName = null)
        {

            ValidateProperty(propertyName, val);

            return base.SetProperty<T>(ref member, val, propertyName);
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {

            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                _propErrors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                _propErrors.Remove(propertyName);
            }

            ErrorsChanged(this,new DataErrorsChangedEventArgs(propertyName));

        }
    }
}
