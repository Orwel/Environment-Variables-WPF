using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.BO
{
    /// <summary>
    /// List of environment varialbes.
    /// </summary>
    public class ListEnvironmentVariables : List<EnvironmentVariable>
    {
        #region Getter/Setter
        /// <summary>
        /// To fill up the list, need target a type of environment variable.
        /// </summary>
        public EnvironmentVariableTarget Target { get; private set; }
        /// <summary>
        /// Get EnvironmentVariable from it name.
        /// Return null if none environment variable has this name.
        /// </summary>
        /// <param name="name">Environment variable's name</param>
        /// <returns>
        /// Return environment variable match parameter name.
        /// Return null if nothing match.
        /// </returns>
        public EnvironmentVariable this[string name]
        {
            get
            {
                foreach (var current in this)
                {
                    if (current.Name == name)
                        return current;
                }
                return null;
            }
        }
        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="target">Type of environment variable</param>
        public ListEnvironmentVariables(EnvironmentVariableTarget target)
        {
            this.Target = target;
        }

        /// <summary>
        /// Clone the list of environment variable.
        /// </summary>
        /// <returns>A clone of the list of environment variable.</returns>
        public ListEnvironmentVariables Clone()
        {
            var clone = new ListEnvironmentVariables(this.Target);
            clone.AddRange(this);
            return clone;
        }
    }
}
