using NT.ViewModels.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using NT.Utilities;
using Microsoft.Extensions.Logging;
using NT.Logging;

namespace NT.Gui.UserControls
{
    /// <summary>
    /// Interaction logic for OrdersControl.xaml
    /// </summary>
    public partial class OrdersControl : UserControl
    {
        #region Fields
        private readonly OrderViewModel viewModel;
        private bool isLoaded;
        #endregion

        #region Constructor
        public OrdersControl()
        {
            InitializeComponent();

            // Initialize the viewModel
            viewModel = DataContext as OrderViewModel;
        } 
        #endregion

        #region Event Handlers
        /// <summary>
        /// Initializes the viewModel when the view has been loaded, and prevents reinitialization
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

                // Log Exception
                await Logger.LogAsync(ex);
            }
        } 
        #endregion
    }
}