using Newtonsoft.Json;
using NT.Entities.Models;
using NT.Services.Base;
using NT.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NT.Services
{
    // Class for product services
    public class ProductService : ServiceBase
    {
        /// <summary>
        /// Calls the endpoint to retrieve all products available
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Products"/></returns>
        /// <exception cref="WebServiceException"></exception>
        public virtual async Task<List<Products>> GetAllProductsAsync()
        {
            // Call the web API
            string json = await CallWebApiAsync("http://10.143.74.234:5000/product/all");

            // Deserialize the JSON data into an object list
            List<Products> orderData = JsonConvert.DeserializeObject<List<Products>>(json);

            // Return the object list
            return orderData;
        }

        /// <summary>
        /// Calls the endpoint to retrieve a product by its id
        /// </summary>
        /// <returns>An object of type <see cref="Products"/></returns>
        /// <exception cref="WebServiceException"></exception>
        public virtual async Task<Products> GetProductByIdAsync(int productId)
        {
            // Call the web API
            string json = await CallWebApiAsync($"http://10.143.74.234:5000/product/{productId}");

            // Deserialize the JSON data into an object list
            Products product = JsonConvert.DeserializeObject<Products>(json);

            // Return the object list
            return product;
        }
    }
}