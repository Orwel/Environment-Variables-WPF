using EnvironmentVariablesWPF.BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.DAL
{
    /// <summary>
    /// Class to read the environment variables from registry.
    /// </summary>
    public static class EnvironmentVariablesReader
    {
        /// <summary>
        /// Return user's environment variables
        /// </summary>
        /// <returns>User's environment variables</returns>
        public static ListEnvironmentVariables GetUserVariables()
        {
            return GetListEnvironmentVariables(EnvironmentVariableTarget.User);
        }

        /// <summary>
        ///  Return machine's environment variables
        /// </summary>
        /// <returns>Machine's environment variables</returns>
        public static ListEnvironmentVariables GetMachineVariables()
        {
            return GetListEnvironmentVariables(EnvironmentVariableTarget.Machine);
        }

        /// <summary>
        /// Return proccess's environment variables
        /// </summary>
        /// <returns>Proccess's environment variables</returns>
        public static ListEnvironmentVariables GetProccessVariables()
        {
            return GetListEnvironmentVariables(EnvironmentVariableTarget.Process);
        }

        /// <summary>
        /// Return target's environment variables
        /// </summary>
        /// <param name="target">Type of environment variables</param>
        /// <returns>Target's environment variables</returns>
        public static ListEnvironmentVariables GetListEnvironmentVariables(EnvironmentVariableTarget target)
        {
            var variables = new ListEnvironmentVariables(target);
            Refresh(variables);
            return variables;
        }

        /// <summary>
        /// Reload the list from last target used to fill up the list.
        /// </summary>
        public static void Refresh(ListEnvironmentVariables variables)
        {
            variables.Clear();
            var dicVariables = Environment.GetEnvironmentVariables(variables.Target);
            foreach (DictionaryEntry variable in dicVariables)
            {
                variables.Add(new EnvironmentVariable((string)variable.Key, (string)variable.Value));
            }
        }

        /// <summary>
        /// Compare this object with the registre.
        /// </summary>
        /// <returns>True if some modification is ocured.</returns>
        public static bool IsModified(ListEnvironmentVariables variables)
        {
            var registreList = GetListEnvironmentVariables(variables.Target);
            //If size is diffirent, then add or remove is ocured.
            if (variables.Count != registreList.Count)
                return true;
            //If one (or more) variable is modified.
            foreach(var variable in variables)
                if (!registreList.Contains(variable)) 
                    return true;
           return false;
        }
    }
}
