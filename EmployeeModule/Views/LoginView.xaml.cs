using EmployeeModuleNamespace.Interfaces;
using System.Security;
using System.Windows.Controls;

namespace EmployeeModuleNamespace.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : IContainPassword
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public SecureString Password => PasswordBox.SecurePassword;
    }
}
