using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.BO
{
    public class ListEnvironmentVariables : List<EnvironmentVariable>
    {
        #region Getter/Setter
        /// <summary>
        /// To fill up the list, need target a type of environment variable.
        /// </summary>
        public EnvironmentVariableTarget Target { get; private set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_target">Type of environment variable</param>
        public ListEnvironmentVariables(EnvironmentVariableTarget target)
        {
            this.Target = target;
        }
    }
}
