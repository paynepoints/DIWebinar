using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureLogin
{
    public class AppState : ViewModels.ViewModelBase, IAppState
    {
        private Services.ILoginService _loginService;

        private bool _isUserLoggedIn = false;
        private bool _isAppNotSecure = true;

        public AppState(Services.ILoginService loginService)
        {
            _loginService = loginService;

            _loginService.LoggedIn += _loginService_LoggedIn;
        }

        

        public bool IsUserLoggedIn
        {
            get
            {
                return _isUserLoggedIn;
            }
            private set
            {
                SetProperty(ref _isUserLoggedIn, value);
            }
        }

        public bool IsAppNotSecure
        {
            get
            {
                return _isAppNotSecure;
            }
            private set
            {
                SetProperty(ref _isAppNotSecure, value);
            }
        }


        private void _loginService_LoggedIn(object sender, EventArgs e)
        {
            IsUserLoggedIn = true;
            IsAppNotSecure = false;
        }
    }
}
