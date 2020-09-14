using NT.ViewModels.ViewModels;
using System;
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
                // Get the exception which was originally thrown
                Exception originalException = ex.GetOriginalException();

                // Output error message
                MessageBox.Show(originalException.Message, "Der opstod en fejl.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}