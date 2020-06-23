using AspNetDistributedCaching.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetDistributedCaching.Core.Repositories
{
    public interface ICatalogRepository
    {
        Task<IList<Category>> GetCategories();
        Task<Category> GetCategory(string slug);
        Task<Product> GetProduct(string slug);
        Task<IList<Product>> GetProductsByCategory(string slug);
    }
}