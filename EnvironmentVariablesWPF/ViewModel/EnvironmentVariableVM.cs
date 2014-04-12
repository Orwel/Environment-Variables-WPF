using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentVariablesWPF.BO;
using System.ComponentModel;

namespace EnvironmentVariablesWPF.ViewModel
{
    public class EnvironmentVariableVM : INotifyPropertyChanged
    {
        private EnvironmentVariable _variable;

        #region Getter/Setter
        public string Name { get { return _variable.Name; } set { _variable.Name = value; OnPropertyChanged("Name"); } }
        public string Value { get { return _variable.Value; } set { _variable.Value = value; OnPropertyChanged("Value"); } }
        #endregion

        public EnvironmentVariableVM(EnvironmentVariable environmentVariable)
        {
            _variable = environmentVariable;
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
