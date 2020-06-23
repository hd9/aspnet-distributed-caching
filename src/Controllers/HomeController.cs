using AspNetDistributedCaching.Core.Services;
using AspNetDistributedCaching.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AspNetDistributedCaching.Controllers
{
    public class HomeController : Controller
    {
        
        readonly ICatalogSvc _svc;

        public HomeController(ICatalogSvc svc)
        {
            _svc = svc;
        }

        /// <summary>
        /// Index: Display all categories
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var cats = await _svc.GetCategories();
            return View(cats);
        }

        /// <summary>
        /// View a Category
        /// </summary>
        /// <returns></returns>
        [Route("/{catName}")]
        public async Task<IActionResult> ViewCategory(string catName)
        {
            var prods = await _svc.GetProductsByCategory(catName);
            return View(prods);
        }

        /// <summary>
        /// View a product
        /// </summary>
        /// <param name="catName"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [Route("/{catName}/{product}")]
        public async Task<IActionResult> ViewProduct(string catName, string product)
        {
            var prods = await _svc.GetProduct(product);
            return View(prods);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
