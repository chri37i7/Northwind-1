using Newtonsoft.Json;
using NT.Entities.Models;
using NT.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using NT.Entities;

namespace NT.Services
{
    // Class for order Services
    public class ShipperService : ServiceBase
    {
        /// <summary>
        /// Calls the endpoint to retrieve all shippers available
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Shippers"/></returns>
        /// <exception cref="WebServiceException"></exception>
        public virtual async Task<List<Shippers>> GetAllShippersAsync()
        {
            // Call the web API
            string json = await CallWebApiAsync("http://10.143.74.234:5000/shipper/all");

            // Deserialize the JSON data into an object list
            List<Shippers> shipperData = JsonConvert.DeserializeObject<List<Shippers>>(json);

            // Return the object list
            return shipperData;
        }
    }
}