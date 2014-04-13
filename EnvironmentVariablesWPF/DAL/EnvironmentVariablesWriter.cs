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
            var ListToEditOrAdd = variables.Clone();
            var registreList = EnvironmentVariablesReader.GetListEnvironmentVariables(variables.Target);
            var listToRemove = new List<EnvironmentVariable>();

            foreach (var variable in registreList)
            {
                EnvironmentVariable find = ListToEditOrAdd[variable.Name];
                if (find == null)
                {
                    listToRemove.Add(variable);
                }
                else
                {
                    if(find.Value == variable.Value)
                        ListToEditOrAdd.Remove(find);
                }
            }
            //Apply modification
            ListToEditOrAdd.ForEach(v => Environment.SetEnvironmentVariable(v.Name, v.Value, variables.Target));
            listToRemove.ForEach(v => Environment.SetEnvironmentVariable(v.Name, null, variables.Target));
        }
    }
}
