using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SecureLogin.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl, Services.ISecurePasswordService 
    {
        public Login(IContainerExtension containerRegistry)
        {
            InitializeComponent();
            containerRegistry.RegisterInstance<Services.ISecurePasswordService>(this);

        }

        public SecureString GetSecurePassword()
        {
            return this.SecurePassword.SecurePassword;
        }

        public void ResetPassword()
        {
            this.SecurePassword.Clear();
        }
    }
}
