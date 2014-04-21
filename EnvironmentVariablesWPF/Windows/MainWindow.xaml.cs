using EnvironmentVariablesWPF.BLL;
using EnvironmentVariablesWPF.ViewModel;
using System;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;

namespace EnvironmentVariablesWPF.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
           
            var searchEngine = new MainWindowVM();
            this.DataContext = searchEngine;
            UserVariablesView.Display(searchEngine.SelectedUserVariables, false);
            MachineVariablesView.Display(searchEngine.SelectedMachineVariables, !AdminRigthManager.IsAdmin());
        }

        /// <summary>
        /// Send the modifications to registre.
        /// </summary>
        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((MainWindowVM)this.DataContext).ApplyToRegistry();
            }
            catch(Exception ex)
            {
                MessageRepporting.ExceptionNoHandled(ex); 
            }
        }

        /// <summary>
        /// Before close this window, verify if some modifications are occured.
        /// If true, then ask to user if he want save this modificaitons.
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                if (EnvironmentVariableManager.SomeModificationIsOccured())
                    if (MessageBox.Show("Before exit this programm, do you want apply this modification to registre?",
                        "Some modification will be lose", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        EnvironmentVariableManager.ApplyToRegistry();
            }
            catch (Exception ex)
            {
                MessageRepporting.ExceptionNoHandled(ex); 
            }
        }

        /// <summary>
        /// Real time to search engine. Each modified text drag along a new search.
        /// </summary>
        private void TextBoxSearchEngine_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                if (textBox == null)
                    return;
                var searchEngine = this.DataContext as MainWindowVM;
                if (searchEngine != null)
                    searchEngine.Select(textBox.Text);
            }
            catch (Exception ex)
            {
                MessageRepporting.ExceptionNoHandled(ex);
            }
        }
    }
}
