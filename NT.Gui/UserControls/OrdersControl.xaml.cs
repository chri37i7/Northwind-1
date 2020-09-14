using NT.ViewModels.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NT.Gui.UserControls
{
    /// <summary>
    /// Interaction logic for OrdersControl.xaml
    /// </summary>
    public partial class OrdersControl : UserControl
    {
        private readonly OrderViewModel viewModel;
        private bool isLoaded;

        public OrdersControl()
        {
            InitializeComponent();

            // Initialize the viewModel
            viewModel = DataContext as OrderViewModel;
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