using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureLogin
{
    public interface IAppState
    {
        bool IsUserLoggedIn { get; }
        bool IsAppNotSecure { get; }
    }
}
