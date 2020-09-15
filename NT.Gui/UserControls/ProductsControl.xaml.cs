using NT.ViewModels.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace NT.Gui.UserControls
{
    /// <summary>
    /// Interaction logic for ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        private readonly ProductViewModel viewModel;
        private bool isLoaded;

        public ProductsControl()
        {
            InitializeComponent();

            // Initialize the viewModel
            viewModel = DataContext as ProductViewModel;
        }

        /// <summary>
        /// Initializes the viewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if this has already been loaded
                if(!isLoaded)
                {
                    // Change isLoaded value
                    isLoaded = !isLoaded;

                    // Initialize the viewModel
                    await viewModel.InitializeAsync();
                }
            }
            catch(Exception ex)
            {
                // Output error message
                MessageBox.Show(ex.Message, "Der opstod en fejl.", MessageBoxButton.OK, MessageBoxImage.Error);

                // Write error to a logging file, which will be created if it doesn't already exist.
                using StreamWriter writer = File.AppendText($"{Directory.GetCurrentDirectory()}/log.txt");

                // Get original Exception
                Exception original = ex.GetOriginalException();

                // Write exception to file
                writer.Write(
                    $"\nError Message: {ex.Message}\n" +
                    $"Stacktrace:\n{ex.StackTrace}\n" +
                    $"Source: {ex.Source}\n" +
                    $"InnerException: {original.Message} \n" +
                    $"Stracktrace\n{original.StackTrace}\n" +
                    $"Source: {original.Source}\n" +
                    $"Handler: OrdersControl.OnLoaded()");
            }
        }
    }
}