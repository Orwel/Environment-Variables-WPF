using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentVariablesWPF.BO;

namespace EnvironmentVariablesWPF.DAL
{
    public static class EnvironmentVariablesWriter
    {
        /// <summary>
        /// Apply modification in list to registre environment variable.
        /// </summary>
        public static void Apply(ListEnvironmentVariables variables)
        {
            var ListToEditOrAdd = new List<EnvironmentVariable>();
            ListToEditOrAdd.AddRange(variables);
            var registreList = EnvironmentVariablesReader.GetListEnvironmentVariables(variables.Target);
            var listToRemove = new List<EnvironmentVariable>();

            foreach (var variable in registreList)
            {
                EnvironmentVariable find = null;
                foreach (var current in ListToEditOrAdd)
                {
                    if (current.Name == variable.Name)
                    {
                        find = current;
                        break;
                    }
                }
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
