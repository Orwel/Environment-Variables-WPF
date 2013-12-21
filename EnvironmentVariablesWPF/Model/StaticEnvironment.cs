using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.Model
{
    /// <summary>
    /// Global variable for this programm
    /// </summary>
    static class StaticEnvironment
    {
        public static ListEnvironmentVariables listVariablesUser = new ListEnvironmentVariables(EnvironmentVariableTarget.User);
        public static ListEnvironmentVariables listVariablesMachine = new ListEnvironmentVariables(EnvironmentVariableTarget.Machine);
        public static bool AdminPrivilege = false;

        public static void ApplyToRegistre()
        {
            StaticEnvironment.listVariablesUser.Apply();
            if (StaticEnvironment.AdminPrivilege)
                StaticEnvironment.listVariablesMachine.Apply();
        }

        public static bool SomeModificationIsOccured()
        {
            return (StaticEnvironment.listVariablesUser.IsModified() ||
                (StaticEnvironment.AdminPrivilege && StaticEnvironment.listVariablesMachine.IsModified()));
        }
    }
}
