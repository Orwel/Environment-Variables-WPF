using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentVariablesWPF.BO;
using System.ComponentModel;

namespace EnvironmentVariablesWPF.ViewModel
{
    /// <summary>
    /// View Model of EnvironmenVariable
    /// </summary>
    public class EnvironmentVariableVM : INotifyPropertyChanged
    {
        private EnvironmentVariable _variable;

        #region Getter/Setter
        /// <summary>
        /// Name of EnvironmentVariable
        /// </summary>
        public string Name 
        { 
            get { return _variable.Name; } 
            set { _variable.Name = value; OnPropertyChanged("Name"); } 
        }
        /// <summary>
        /// Value of EnvironmentVariable
        /// </summary>
        public string Value 
        { 
            get { return _variable.Value; }
            set { _variable.Value = value; OnPropertyChanged("Value"); OnPropertyChanged("Status"); } 
        }
        /// <summary>
        /// If EnvironmentVariable is deleted in the programn.
        /// </summary>
        public bool IsDelete 
        { 
            get { return _variable.IsDelete; }
            set { _variable.IsDelete = value; OnPropertyChanged("IsDelete"); OnPropertyChanged("Status"); } 
        }
        /// <summary>
        /// State of EnvironmentVariable in the programn.
        /// </summary>
        public EnvironmentVariable.State Status
        {
            get { return _variable.Status; }
        }
        #endregion

        /// <summary>
        /// Contrustor from a reference of EnvironmentVariable.
        /// </summary>
        /// <param name="environmentVariable">Reference of EnvironmentVariable.</param>
        public EnvironmentVariableVM(EnvironmentVariable environmentVariable)
        {
            _variable = environmentVariable;
        }

        #region INotifyPropertyChanged implementation
        /// <summary>
        /// Event is rise after the modification of property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Rise the event PropertyChanged.
        /// </summary>
        /// <param name="name">Name of property who is changed.</param>
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
