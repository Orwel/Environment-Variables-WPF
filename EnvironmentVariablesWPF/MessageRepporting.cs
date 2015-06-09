using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnvironmentVariablesWPF
{
    /// <summary>
    /// Containt all message to user.
    /// </summary>
    public static class MessageRepporting
    {
        /// <summary>
        /// Write exception in stderr and display a short message to user.
        /// </summary>
        /// <param name="ex">Exception caught</param>
        public static void ExceptionNoHandled(Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            MessageBox.Show("Some error has occurred." + Environment.NewLine + ex.Message,
                "Operation failed", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
