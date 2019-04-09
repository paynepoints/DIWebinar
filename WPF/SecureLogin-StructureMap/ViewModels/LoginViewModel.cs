using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecureLogin.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private IContainerExtension _container;
        private Services.ISecurePasswordService _passwordService;
        private Services.ILoginService _loginService;

        private string _email;
        private string _errorText = string.Empty;

        public LoginViewModel(IContainerExtension container, Services.ILoginService loginService)
        {
            _container = container;
            _loginService = loginService;

            LoginCommand = new DelegateCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);
                ((DelegateCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public string ErrorText
        {
            get
            {
                return _errorText;
            }
            set
            {
                SetProperty(ref _errorText, value);
            }
        }

        public ICommand LoginCommand { get; private set; }

        private bool CanExecuteLoginCommand()
        {
            return !string.IsNullOrEmpty(_email);
        }

        private void ExecuteLoginCommand()
        {
            _passwordService = _container.Resolve<Services.ISecurePasswordService>();

            if(_passwordService == null)
            {
                ErrorText = "Security Services are not available";
                return;
            }

            if (!_loginService.Login(Email, _passwordService.GetSecurePassword()))
            {
                ErrorText = "Invalid Email or Password";
            }
            else
            {
                ErrorText = string.Empty;
            }
            Email = string.Empty;
            _passwordService.ResetPassword();
        }

       
    }
}
