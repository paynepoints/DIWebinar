using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SecureLogin.Services
{
    public class LoginService : ILoginService
    {
        public event EventHandler LoggedIn;

        public bool Login(string email, SecureString password)
        {
            if(email == "michael@paynepoints.com")
            {
                //TODO:  Securely hash password and send to server
                OnLoggedIn();
                return true;
            }

            return false;
        }

        private void OnLoggedIn()
        {
            if(LoggedIn != null)
            {
                LoggedIn(this, EventArgs.Empty);
            }
        }
    }
}
