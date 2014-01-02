using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.Model
{
    public static class SearchEngine
    {
        public static ListSelectedVariables selectedUserVariables;
        public static ListSelectedVariables selectedMachineVariables;

        public static void Select(string str)
        {
            if (selectedUserVariables != null)
                selectedUserVariables.Select(str);
            if (selectedMachineVariables != null)
                selectedMachineVariables.Select(str);
        }

        public static void Refresh()
        {
            if (selectedUserVariables != null)
                selectedUserVariables.Refresh();
            if (selectedMachineVariables != null)
                selectedMachineVariables.Refresh();
        }
    }
}
