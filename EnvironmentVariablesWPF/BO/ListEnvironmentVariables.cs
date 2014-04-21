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
                return this.Find(e => e.Name == name);
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

        public void Add(string name, string value)
        {
            this.Add(new EnvironmentVariable(Target, name, value));
        }

        /// <summary>
        /// Set deleted status to environment variable.
        /// If the environment variable is not in resitry, it is removed from the list.
        /// </summary>
        /// <param name="ev">environment variable</param>
        public new void Remove(EnvironmentVariable ev)
        {
            if (ev.Status == EnvironmentVariable.State.NEW)
                base.Remove(ev);
            else
                ev.IsDelete = true;
        }

        /// <summary>
        /// Remove a environment variable from it name.
        /// </summary>
        /// <param name="name">Environment variable's name</param>
        public void Remove(string name)
        {
            this.Remove(this[name]);
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
