using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SecureLogin.Services
{
    public interface ISecurePasswordService
    {

        void ResetPassword();
        SecureString GetSecurePassword();

    }
}
