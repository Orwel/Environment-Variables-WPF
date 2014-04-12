using EnvironmentVariablesWPF.BLL;
using EnvironmentVariablesWPF.BO;
using EnvironmentVariablesWPF.ViewModel;

namespace EnvironmentVariablesWPF.ViewModel
{
    public class SearchEngineVM
    {
        public ListSelectedVariablesVM selectedUserVariables = 
            new ListSelectedVariablesVM(StaticEnvironment.listVariablesUser);
        public ListSelectedVariablesVM selectedMachineVariables = 
            new ListSelectedVariablesVM(StaticEnvironment.listVariablesMachine);

        public void Select(string str)
        {
            if (selectedUserVariables != null)
                selectedUserVariables.Select(str);
            if (selectedMachineVariables != null)
                selectedMachineVariables.Select(str);
        }

        public void Refresh()
        {
            if (selectedUserVariables != null)
                selectedUserVariables.Refresh();
            if (selectedMachineVariables != null)
                selectedMachineVariables.Refresh();
        }
    }
}
