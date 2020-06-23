using AspNetDistributedCaching.Core.Repositories;
using AspNetDistributedCaching.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetDistributedCaching.Core.Services
{
    public class CatalogSvc : ICatalogSvc
    {

        readonly ICatalogRepository _repo;
        readonly IDistributedCache _cache;
        readonly string _keyFmt = ":catalog:{0}:{1}";

        public CatalogSvc(
            ICatalogRepository repo,
            IDistributedCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<IList<Category>> GetCategories()
        {
            return await GetFromCache<IList<Category>>(
                "categories",
                "*",
                async () => await _repo.GetCategories());
        }

        public async Task<Category> GetCategory(string slug)
        {
            return await GetFromCache<Category>(
                "categories",
                "slug",
                async () => await _repo.GetCategory(slug));
        }

        public async Task<Product> GetProduct(string slug)
        {
            return await GetFromCache<Product>(
                "products",
                slug,
                async () => await _repo.GetProduct(slug));
        }

        public async Task<IList<Product>> GetProductsByCategory(string catSlug)
        {
            return await GetFromCache<IList<Product>>(
                "products",
                catSlug,
                async () => await _repo.GetProductsByCategory(catSlug));
        }

        private async Task<TResult> GetFromCache<TResult>(
            string key,
            string val,
            Func<Task<object>> func)
        {
            var cacheKey = string.Format(_keyFmt, key, val);
            var data = await _cache.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(data))
            {
                data = JsonConvert.SerializeObject(await func());

                await _cache.SetStringAsync(
                    cacheKey,
                    data);
            }

            return JsonConvert.
                DeserializeObject<TResult>(data);
        }
    }
}
