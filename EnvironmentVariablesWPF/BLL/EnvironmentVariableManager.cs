using EnvironmentVariablesWPF.DAL;
using EnvironmentVariablesWPF.BO;
using System;
using System.Security;


namespace EnvironmentVariablesWPF.BLL
{
    /// <summary>
    /// Manger of environment variables.
    /// </summary>
    public static class EnvironmentVariableManager
    {
        public static ListEnvironmentVariables ListUserVariables { get; private set; }
        public static ListEnvironmentVariables ListMachineVariables { get; private set; }

        static EnvironmentVariableManager()
        {
            ListUserVariables = EnvironmentVariablesReader.GetUserVariables();
            ListMachineVariables = EnvironmentVariablesReader.GetMachineVariables();
        }

        /// <summary>
        /// Save all modification to the registry
        /// </summary>
        /// <exception cref="ArgumentException">
        /// The length of variable's name is greater than or equal to 255.
        /// or
        /// An error occurred during the execution of this operation.
        /// </exception>
        /// <exception cref="SecurityException">
        /// The caller does not have the required permission to perform this operation.
        /// </exception>
        public static void ApplyToRegistry()
        {
            EnvironmentVariablesWriter.Apply(EnvironmentVariableManager.ListUserVariables);
            if (AdminRigthManager.IsAdmin())
                EnvironmentVariablesWriter.Apply(EnvironmentVariableManager.ListMachineVariables);
        }

        /// <summary>
        /// Compare the programn data with registry data to detect the modification.
        /// </summary>
        /// <returns>True if one or more modification is ocured and is not apply.</returns>
        public static bool SomeModificationIsOccured()
        {
            return EnvironmentVariablesReader.IsModified(EnvironmentVariableManager.ListUserVariables) ||
                   EnvironmentVariablesReader.IsModified(EnvironmentVariableManager.ListMachineVariables);
        }

        /// <summary>
        /// Refresh the lists of environment variables from registry.
        /// </summary>
        public static void Refresh()
        {
            ListUserVariables.Clear();
            ListUserVariables.AddRange(EnvironmentVariablesReader.GetUserVariables());
            ListMachineVariables.Clear();
            ListMachineVariables.AddRange(EnvironmentVariablesReader.GetUserVariables());
        }
    }
}
