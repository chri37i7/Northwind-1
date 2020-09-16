using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using NT.Logging;
using NT.Utilities;

namespace NT.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Logs unhandled exceptions to a file in the current directory location of the executable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Log error
            Logger.Log(e.Exception);

            // Prevent default unhandled exception processing
            e.Handled = true;
        }
    }
}