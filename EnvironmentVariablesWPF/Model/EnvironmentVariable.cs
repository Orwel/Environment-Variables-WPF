using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.Model
{
    /// <summary>
    /// Describe a Windows environment variable.
    /// A environment variable is a pair of name and value.
    /// </summary>
    public class EnvironmentVariable : INotifyPropertyChanged
    {
        /// <summary>
        /// Environment variable's name
        /// </summary>
        private string name;

        /// <summary>
        /// Environment variable's value
        /// </summary>
        private string value;

        #region Getter/Setter
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Value { get { return this.value; } set { this.value = value; OnPropertyChanged("Value"); } }
        #endregion

        public EnvironmentVariable(string _name="", string _value="")
        {
            name = _name;
            value = _value;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
