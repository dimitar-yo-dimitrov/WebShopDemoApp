using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Contracts;
using WebShop.Core.Models;

namespace WebShop.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            ViewData["Title"] = "Products";

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductDto();
            ViewData["Title"] = "Add new product";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new product";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _productService.Add(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete() => RedirectToAction(nameof(Index));

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            Guid idGuid = Guid.Parse(id);
            await _productService.Delete(idGuid);

            return RedirectToAction(nameof(Index));
        }
    }
}
