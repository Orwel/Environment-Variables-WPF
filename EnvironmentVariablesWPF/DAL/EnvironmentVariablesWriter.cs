using System;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentVariablesWPF.BO;

namespace EnvironmentVariablesWPF.DAL
{
    /// <summary>
    /// Class to write the environment variables to registry.
    /// </summary>
    public static class EnvironmentVariablesWriter
    {
        /// <summary>
        /// Apply modification in list to registre environment variable.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// The length of variable's name is greater than or equal to 255.
        /// or
        /// An error occurred during the execution of this operation.
        /// </exception>
        /// <exception cref="SecurityException">
        /// The caller does not have the required permission to perform this operation.
        /// </exception>
        public static void Apply(ListEnvironmentVariables variables)
        {
            variables.ForEach(v =>
                {
                    switch (v.Status)
                    {
                        case EnvironmentVariable.State.NEW:
                        case EnvironmentVariable.State.EDIT:
                            Environment.SetEnvironmentVariable(v.Name, v.Value, variables.Target);
                            break;
                        case EnvironmentVariable.State.DELETE:
                            Environment.SetEnvironmentVariable(v.Name, null, variables.Target);
                            break;
                    }
                });
        }
    }
}
