using System.Security;
using System.Windows.Controls;
using EmployeeModuleNamespace.Interfaces;

namespace EmployeeModuleNamespace.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl, IContainPassword
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public SecureString Password => PasswordBox.SecurePassword;
    }
}
