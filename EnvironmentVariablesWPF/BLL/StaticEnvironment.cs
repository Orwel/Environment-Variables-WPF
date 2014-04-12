using EnvironmentVariablesWPF.DAL;
using EnvironmentVariablesWPF.BO;

namespace EnvironmentVariablesWPF.BLL
{
    /// <summary>
    /// Global variable for this programm
    /// </summary>
    static class StaticEnvironment
    {
        public static ListEnvironmentVariables listVariablesUser = EnvironmentVariablesReader.GetUserVariables();
        public static ListEnvironmentVariables listVariablesMachine = EnvironmentVariablesReader.GetMachineVariables();

        public static void ApplyToRegistre()
        {
            EnvironmentVariablesWriter.Apply(StaticEnvironment.listVariablesUser);
            if (AdminRight.IsAdmin())
                EnvironmentVariablesWriter.Apply(StaticEnvironment.listVariablesMachine);
        }

        public static bool SomeModificationIsOccured()
        {
            return EnvironmentVariablesReader.IsModified(StaticEnvironment.listVariablesUser) ||
                   EnvironmentVariablesReader.IsModified(StaticEnvironment.listVariablesMachine);
        }
    }
}
