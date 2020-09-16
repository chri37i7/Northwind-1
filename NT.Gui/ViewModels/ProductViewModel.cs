using NT.Entities.Models;
using NT.Utilities;
using NT.Gui.ViewModels.Base;
using NT.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NT.ViewModels.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        #region Fields
        ObservableCollection<Products> products;
        Products selectedProduct; 
        #endregion

        #region Constructor
        public ProductViewModel()
        {
            products = new ObservableCollection<Products>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// The displayed products in the view
        /// </summary>
        public ObservableCollection<Products> Products
        {
            get
            {
                return products;
            }
            set
            {
                SetProperty(ref products, value);
            }
        }

        /// <summary>
        /// The Selectec Product in the view
        /// </summary>
        public Products SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                SetProperty(ref selectedProduct, value);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads all products from the web API
        /// </summary>
        /// <returns></returns>
        protected override async Task LoadAllAsync()
        {
            // Declare service object
            ProductService service = new ProductService();
            // Get all products from the API
            List<Products> products = await service.GetAllProductsAsync();
            // Replace collection without destroying it
            Products.ReplaceWith(products);
        } 
        #endregion
    }
}