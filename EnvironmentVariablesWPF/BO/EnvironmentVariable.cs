using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.BO
{
    /// <summary>
    /// Describe a Windows environment variable.
    /// A environment variable is a pair of name and value.
    /// </summary>
    public class EnvironmentVariable : IEquatable<EnvironmentVariable>
    {
        #region Getter/Setter
        /// <summary>
        /// Name of environment variable
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value of environment variable
        /// </summary>
        public string Value { get; set; }
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">Name of environment variable</param>
        /// <param name="value">Value of environment variable</param>
        public EnvironmentVariable(string name="", string value="")
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Equal of name and value.
        /// </summary>
        /// <param name="v1">Environment variable right</param>
        /// <param name="v2">Environment variable left</param>
        /// <returns>True if their names and values ​​are the same.</returns>
        public static bool operator ==(EnvironmentVariable v1, EnvironmentVariable v2)
        {
            if (object.ReferenceEquals(v1, v2))
                return true;
            if (object.ReferenceEquals(v1, null) || object.ReferenceEquals(v2, null))
            {
                return false;
            }
            return v1.Name == v2.Name && v1.Value == v2.Value;
        }

        /// <summary>
        /// Different of name or value.
        /// </summary>
        /// <param name="v1">Environment variable right</param>
        /// <param name="v2">Environment variable left</param>
        /// <returns>True returns true if their names or values ​​are not the same</returns>
        public static bool operator !=(EnvironmentVariable v1, EnvironmentVariable v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Implement IEquatable to search in list.
        /// Equal of name and value.
        /// </summary>
        /// <param name="other">Environment variable to compare.</param>
        /// <returns>True if their names and values ​​are the same.</returns>
        public bool Equals(EnvironmentVariable other)
        {
            return this == other;
        }

        #region Object Override
        /// <summary>
        /// Equal of type and name and value.
        /// </summary>
        /// <param name="o">Environment variable object</param>
        /// <returns>
        /// True if o is EnvironmentVariable object and
        /// their names and values ​​are the same.
        /// </returns>
        public override bool Equals(Object o)
        {
            var variable = o as EnvironmentVariable;
            if (object.ReferenceEquals(variable, null))
                return false;
            return this.Equals(variable);
        }

        /// <summary>
        /// ??????????
        /// </summary>
        /// <returns>??????????</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
