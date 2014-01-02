using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.Model
{
    /// <summary>
    /// List of selected variable from search engine.
    /// </summary>
    public class ListSelectedVariables : BindingList<EnvironmentVariable>
    {
        /// <summary>
        /// Initial list.
        /// </summary>
        private ListEnvironmentVariables refList;

        /// <summary>
        /// Use to compare from initial list to field name and value.
        /// </summary>
        private string searchStr = "";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_refList">Ref. to use in search engine.</param>
        public ListSelectedVariables(ListEnvironmentVariables _refList)
        {
            refList = _refList;
            Refresh();
        }

        /// <summary>
        /// Reload the selected list with last parameters.
        /// </summary>
        public void Refresh()
        {
            Clear();
            if (String.IsNullOrEmpty(searchStr))
            {
                foreach (var variable in refList)
                    Add(variable);
            }
            else
            {
                foreach (var variable in refList)
                {
                    if (variable.Name.IndexOf(searchStr, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        variable.Value.IndexOf(searchStr, StringComparison.OrdinalIgnoreCase) >= 0)
                        Add(variable);
                }
            }
        }

        /// <summary>
        /// Select environment variable if the parameter string contains in field of name or value.
        /// This method is not case sensitive.
        /// </summary>
        /// <param name="str">String to verify if it is contained in name or value.</param>
        public void Select(string str)
        {
            searchStr = str;
            Refresh();
        }

        public void AddToOriginalList(EnvironmentVariable ev)
        {
            refList.Add(ev);
            Refresh();
        }

        public void RemoveToRefList(EnvironmentVariable ev)
        {
            refList.Remove(ev);
            Refresh();
        }
    }
}
