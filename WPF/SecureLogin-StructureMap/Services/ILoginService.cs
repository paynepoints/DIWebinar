using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SecureLogin.Services
{
    public interface ILoginService
    {
        event EventHandler LoggedIn;

        bool Login(string email, SecureString password);

    }
}
