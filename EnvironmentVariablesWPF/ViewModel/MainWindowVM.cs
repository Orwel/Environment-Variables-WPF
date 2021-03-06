﻿using EnvironmentVariablesWPF.BLL;
using EnvironmentVariablesWPF.BO;
using EnvironmentVariablesWPF.ViewModel;

namespace EnvironmentVariablesWPF.ViewModel
{
    /// <summary>
    /// View model of MainWindow.
    /// </summary>
    public class MainWindowVM
    {
        /// <summary>
        /// List of user environment variables with a filter
        /// </summary>
        public ListSelectedVariablesVM SelectedUserVariables { get; private set; }
        /// <summary>
        /// List of machine environment variables with a filter
        /// </summary>
        public ListSelectedVariablesVM SelectedMachineVariables { get; private set; }

        /// <summary>
        /// Default constructor.
        /// Initialise User and Machine list of environment variables.
        /// </summary>
        public MainWindowVM()
        {
            SelectedUserVariables = new ListSelectedVariablesVM(EnvironmentVariableManager.ListUserVariables);
            SelectedMachineVariables = new ListSelectedVariablesVM(EnvironmentVariableManager.ListMachineVariables);
        }

        /// <summary>
        /// Select the environment variables which contains the filter in it name or it value. 
        /// </summary>
        /// <param name="filter">Filter</param>
        public void Select(string filter)
        {
            SelectedUserVariables.Select(filter);
            SelectedMachineVariables.Select(filter);
        }

        /// <summary>
        /// Refresh the list with the last filter.
        /// </summary>
        public void Refresh()
        {
            SelectedUserVariables.Refresh();
            SelectedMachineVariables.Refresh();
        }

        /// <summary>
        /// Apply the modification in registry and reload the list.
        /// </summary>
        public void ApplyToRegistry()
        {
            EnvironmentVariableManager.ApplyToRegistry();
            EnvironmentVariableManager.Refresh();
            this.Refresh();
        }

        /// <summary>
        /// Return if some modification is ocurred in the environment variable lists.
        /// </summary>
        /// <returns></returns>
        public bool SomeModificationIsOccured()
        {
            return EnvironmentVariableManager.SomeModificationIsOccured();
        }
    }
}
