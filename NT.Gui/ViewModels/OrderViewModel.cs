using NT.Entities.Models;
using NT.Gui;
using NT.Gui.ViewModels.Base;
using NT.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NT.ViewModels.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        #region Fields
        protected ObservableCollection<Shippers> shippers;
        protected ObservableCollection<Orders> orders;
        protected Orders selectedOrder;
        #endregion

        #region Constructor
        public OrderViewModel()
        {
            Shippers = new ObservableCollection<Shippers>();
            Orders = new ObservableCollection<Orders>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// The available shippers in the view
        /// </summary>
        public virtual ObservableCollection<Shippers> Shippers
        {
            get
            {
                return shippers;
            }
            set
            {
                SetProperty(ref shippers, value);
            }
        }

        /// <summary>
        /// The displayed orders in the view
        /// </summary>
        public virtual ObservableCollection<Orders> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                SetProperty(ref orders, value);
            }
        }

        /// <summary>
        /// The selected order in the view
        /// </summary>
        public virtual Orders SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                SetProperty(ref selectedOrder, value);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads all orders from the web API
        /// </summary>
        protected override async Task LoadAllAsync()
        {
            // Declare service object
            OrderService orderService = new OrderService();
            // Get all orders from the API
            List<Orders> orders = await orderService.GetAllOrdersAsync();
            // Replace collection without destroying it
            Orders.ReplaceWith(orders);

            // Declare service object
            ShipperService shipperService = new ShipperService();
            // Get all shippers from the API
            List<Shippers> shippers = await shipperService.GetAllShippersAsync();
            // Replace collection without destroying it
            Shippers.ReplaceWith(shippers);
        }
        #endregion
    }
}