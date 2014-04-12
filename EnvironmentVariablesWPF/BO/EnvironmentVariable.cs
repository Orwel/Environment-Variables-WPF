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
        public string Name { get; set; }
        public string Value { get; set; }
        #endregion

        public EnvironmentVariable(string name="", string value="")
        {
            Name = name;
            Value = value;
        }

        public static bool operator ==(EnvironmentVariable v1, EnvironmentVariable v2)
        {
            return v1.Name == v2.Name && v1.Value == v2.Value;
        }

        public static bool operator !=(EnvironmentVariable v1, EnvironmentVariable v2)
        {
            return v1.Name != v2.Name || v1.Value != v2.Value; ;
        }

        public bool Equals(EnvironmentVariable other)
        {
            return this == other;
        }

        #region Object Override
        public override bool Equals(Object o)
        {
            var variable = o as EnvironmentVariable;
            if (o == null)
                return false;
            return this.Equals(variable);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
