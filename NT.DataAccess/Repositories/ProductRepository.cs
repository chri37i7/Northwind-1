using Microsoft.EntityFrameworkCore;
using NT.DataAccess.RepositoryBase;
using NT.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NT.DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Products>
    {
        /// <summary>
        /// Override to include the category of a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Products> GetByIdAsync(int id)
        {
            return await context.Products
                .Include("Category")
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        /// <summary>
        /// Override to include the category of products
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await context.Set<Products>()
                .Include("Category")
                .Where(p => p.UnitsInStock < 10)
                .ToListAsync();
        }
    }
}