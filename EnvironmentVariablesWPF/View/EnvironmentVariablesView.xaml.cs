using EnvironmentVariablesWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnvironmentVariablesWPF.View
{
    /// <summary>
    /// Logique d'interaction pour EnvironmentVariablesView.xaml
    /// </summary>
    public partial class EnvironmentVariablesView : UserControl
    {
        private bool readOnly = false;


        public EnvironmentVariablesView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display the list of environment variables in view.
        /// </summary>
        /// <param name="source">List of environment variables</param>
        /// <param name="readOnly">True, display warning message. False, button to edit is visible.</param>
        public void Display(ListEnvironmentVariables source, bool readOnly)
        {
            DataGridVariables.ItemsSource = source;
            if (readOnly)
            {
                ButtonsPannel.Visibility = System.Windows.Visibility.Collapsed;
                LabelNoPermission.Visibility = System.Windows.Visibility.Visible;
                this.readOnly = readOnly;
            }
        }

        /// <summary>
        /// Add new variable in list.
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var listVariables = DataGridVariables.ItemsSource as ListEnvironmentVariables;
            if (listVariables != null)
            {
                EnvironmentVariable variable = new EnvironmentVariable();
                var EditWin = new EditWindow();
                EditWin.DataContext = variable;
                if (EditWin.ShowDialog() == true)
                    listVariables.Add(variable);
            }
        }

        /// <summary>
        /// Modify the selected variable.
        /// </summary>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditVariable();
        }

        /// <summary>
        /// Delete the selected environment variable.
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var listVariables = DataGridVariables.ItemsSource as ListEnvironmentVariables;
            if (listVariables != null)
            {
                var variable = DataGridVariables.SelectedItem as EnvironmentVariable;
                if (variable != null)
                    listVariables.Remove(variable);
                else
                    MessageBox.Show("Any selected variable","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void EditVariable()
        {
            var listVariables = DataGridVariables.ItemsSource as ListEnvironmentVariables;
            if (listVariables != null)
            {
                var selectedVariable = DataGridVariables.SelectedItem as EnvironmentVariable;
                if (selectedVariable == null)
                    MessageBox.Show("Any selected variable", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    EnvironmentVariable variable = new EnvironmentVariable();
                    variable.Name = selectedVariable.Name;
                    variable.Value = selectedVariable.Value;
                    var EditWin = new EditWindow();
                    EditWin.DataContext = variable;
                    if (EditWin.ShowDialog() == true)
                    {
                        selectedVariable.Name = variable.Name;
                        selectedVariable.Value = variable.Value;
                    }
                }
            }
        }

        private void Edit_DataGrid(object sender, MouseButtonEventArgs e)
        {
            DataGridRow dgr = sender as DataGridRow;
            if (!readOnly && dgr != null)
                EditVariable();
        }
    }
}
