using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Services;
using NerdStore.Catalog.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProductsController : Controller
    {
        private readonly IProductAppService _productAppService;

        public AdminProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("admin-products")]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAll());
        }

        [Route("new-product")]
        public async Task<IActionResult> NewProduct()
        {
            return View(await PopulateCategories(new ProductViewModel()));
        }

        [HttpPost]
        [Route("new-product")]
        public async Task<IActionResult> NewProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(await PopulateCategories(productViewModel));

            await _productAppService.Add(productViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit-product")]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            return View(await PopulateCategories(await _productAppService.GetById(id)));
        }

        [HttpPost]
        [Route("edit-product")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            var product = await _productAppService.GetById(id);
            productViewModel.StockQuantity = product.StockQuantity;

            ModelState.Remove("StockQuantity");
            if (!ModelState.IsValid) return View(await PopulateCategories(productViewModel));

            await _productAppService.Update(productViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("product-update-stock")]
        public async Task<IActionResult> UpdateStock(Guid id)
        {
            return View("Stock", await _productAppService.GetById(id));
        }

        [HttpPost]
        [Route("product-update-stock")]
        public async Task<IActionResult> UpdateStock(Guid id, int quantity)
        {
            if (quantity > 0)
            {
                await _productAppService.StockAdd(id, quantity);
            }
            else
            {
                await _productAppService.StockDebit(id, quantity);
            }

            return View("Index", await _productAppService.GetAll());
        }

        private async Task<ProductViewModel> PopulateCategories(ProductViewModel productViewModel)
        {
            productViewModel.Categories = await _productAppService.GetCategories();
            return productViewModel;
        }
    }
}
