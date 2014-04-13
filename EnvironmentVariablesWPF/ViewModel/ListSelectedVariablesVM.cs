using EnvironmentVariablesWPF.BO;
using System;
using System.ComponentModel;
using System.Linq;


namespace EnvironmentVariablesWPF.ViewModel
{
    /// <summary>
    /// List of selected variable from search engine.
    /// </summary>
    public class ListSelectedVariablesVM : BindingList<EnvironmentVariableVM>
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
        public ListSelectedVariablesVM(ListEnvironmentVariables _refList)
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
                foreach(var variable in refList)
                {
                    this.Add(new EnvironmentVariableVM(variable));
                }
            }
            else
            {
                var selectVariables = refList.Where
                           (v => (v.Name.IndexOf(searchStr, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            v.Value.IndexOf(searchStr, StringComparison.OrdinalIgnoreCase) >= 0));
                foreach (var variable in selectVariables)
                {
                    this.Add(new EnvironmentVariableVM(variable));
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

        /// <summary>
        /// Add a new environment variable to original list.
        /// </summary>
        /// <param name="ev">new environment variable</param>
        public void AddToOriginalList(EnvironmentVariable ev)
        {
            refList.Add(ev);
            Refresh();
        }

        /// <summary>
        /// Remove a environment variable from original list.
        /// </summary>
        /// <param name="ev">removed environment variable</param>
        public void RemoveToRefList(EnvironmentVariable ev)
        {
            refList.Remove(ev);
            Refresh();
        }
    }
}
