using EnvironmentVariablesWPF.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnvironmentVariablesWPF
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Start up of application
        /// </summary>
        /// <param name="sender">App ref</param>
        /// <param name="e">Args of launch</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            using (var stderr = new StreamWriter("stderr"))
            {
                Console.SetError(stderr);
                try
                {
                    (new MainWindow()).ShowDialog();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }
    }
}
