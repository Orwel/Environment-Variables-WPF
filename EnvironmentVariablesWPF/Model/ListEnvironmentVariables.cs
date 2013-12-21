using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariablesWPF.Model
{
    public class ListEnvironmentVariables : BindingList<EnvironmentVariable>
    {
        /// <summary>
        /// To fill up the list, need target a type of environment variable.
        /// </summary>
        private EnvironmentVariableTarget target;

        #region Getter/Setter
        public EnvironmentVariableTarget Target { get { return target; } }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_target">Type of environment variable</param>
        public ListEnvironmentVariables(EnvironmentVariableTarget _target)
        {
            FillUp(_target);
        }

        /// <summary>
        /// Fill up the list with registre environment variable
        /// </summary>
        /// <param name="target">Type of environment variable</param>
        public void FillUp(EnvironmentVariableTarget target)
        {
            this.target = target;
            Refresh();
        }

        /// <summary>
        /// Reload the list from last target used to fill up the list.
        /// </summary>
        public void Refresh()
        {
            Clear();
            var variables = Environment.GetEnvironmentVariables(target);
            foreach (DictionaryEntry variable in variables)
            {
                Add(new EnvironmentVariable((string)variable.Key,(string)variable.Value));
            }
        }

        /// <summary>
        /// Apply modification in list to registre environment variable.
        /// </summary>
        public void Apply()
        {
            var registreList = new ListEnvironmentVariables(target);
            var listToRemove = new List<EnvironmentVariable>();
            foreach(var variable in registreList)
            {
                EnvironmentVariable find = null;
                foreach (var current in this)
                {
                    if (current.Name == variable.Name)
                    {
                        find = current;
                        break;
                    }
                }
                if (find == null)
                {
                    listToRemove.Add(variable);
                }
                else
                {
                    if (find.Value != variable.Value)
                        Environment.SetEnvironmentVariable(find.Name, find.Value, target);
                    Remove(find);
                }
            }

            foreach (var addVariable in this)
            {
                Environment.SetEnvironmentVariable(addVariable.Name, addVariable.Value, target);
            }

            foreach (var removeVariable in listToRemove)
            {
                Environment.SetEnvironmentVariable(removeVariable.Name, null, target);
            }
            Refresh();
        }

        /// <summary>
        /// Compare this object with the registre.
        /// </summary>
        /// <returns>True if some modification is ocured.</returns>
        public bool IsModified()
        {
            var registreList = new ListEnvironmentVariables(target);
            foreach (var current in this)
            {
                EnvironmentVariable find = null;
                foreach (var registreVariable in registreList)
                {
                    if (current.Name == registreVariable.Name)
                    {
                        //If same name and different value, then it is EDIT variable.
                        if(current.Value != registreVariable.Value)
                            return true;
                        find = registreVariable;
                        break;
                    }
                }
                //If any variable is find in registre, then it is ADD variable.
                if (find == null)
                    return true;
                registreList.Remove(find);
            }
            //If registre have more variable, then it is DELETE variable.
            if(registreList.Count>0)
                return true;
            return false;
        }
    }
}
