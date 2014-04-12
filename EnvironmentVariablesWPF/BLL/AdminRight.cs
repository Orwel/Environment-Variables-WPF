using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.BLL
{
    public static class AdminRight
    {
        public static bool IsAdmin()
        {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(user);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
