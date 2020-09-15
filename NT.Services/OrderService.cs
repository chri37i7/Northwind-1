using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NT.Entities;
using NT.Entities.Models;
using NT.Services.Base;

namespace NT.Services
{
    // Class for order Services
    public class OrderService : ServiceBase
    {
        /// <summary>
        /// Calls the endpoint to retrieve all orders available
        /// </summary>
        /// <returns>A list of orders </returns>
        /// <exception cref="WebServiceException"></exception>
        public virtual async Task<List<Orders>> GetAllOrdersAsync()
        {
            // Call the web API
            string json = await CallWebApiAsync("http://10.143.74.234:5000/order/all");

            // Deserialize the JSON data into an object list
            List<Orders> orderData = JsonConvert.DeserializeObject<List<Orders>>(json);

            // Return the object list
            return orderData;
        }

        /// <summary>
        /// Calls the endpoint to retrieve an order by its id
        /// </summary>
        /// <returns>An object of type <see cref="Orders"/></returns>
        /// <exception cref="WebServiceException"></exception>
        public virtual async Task<List<Orders>> GetOrdersByIdAsync(string customerId)
        {
            // Call the web API
            string json = await CallWebApiAsync($"http://10.143.74.234:5000/order/all/{customerId}");

            // Deserialize the JSON data into an object list
            List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(json);

            // Return the object list
            return orders;
        }
    }
}