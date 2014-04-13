using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.BLL
{
    /// <summary>
    /// Mangager of Admin right.
    /// Can determine if currennt user have admin right.
    /// </summary>
    public static class AdminRigthManager
    {
        /// <summary>
        /// Return true if the current user of program have admin right.
        /// </summary>
        /// <returns>True if the current user of program have admin right.</returns>
        public static bool IsAdmin()
        {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(user);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
