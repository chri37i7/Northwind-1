using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;

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
            // Write error to a logging file, which will be created if it doesn't already exist.
            using(StreamWriter writer = File.AppendText($"{Directory.GetCurrentDirectory()}/log.txt"))
            {
                // Get original Exception
                Exception original = e.Exception.GetOriginalException();

                // Write exception to file
                writer.Write(
                    $"\nError Message: {e.Exception.Message}\n" +
                    $"Stacktrace:\n{e.Exception.StackTrace}\n" +
                    $"Source: {e.Exception.Source}\n" +
                    $"InnerException: {original.Message} \n" +
                    $"Stracktrace\n{original.StackTrace}\n" +
                    $"Source: {original.Source}\n");
            }

            // Prevent default unhandled exception processing
            e.Handled = true;
        }
    }
}