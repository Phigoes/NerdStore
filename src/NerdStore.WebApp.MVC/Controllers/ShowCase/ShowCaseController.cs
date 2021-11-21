using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Services;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Controllers.ShowCase
{
    public class ShowCaseController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ShowCaseController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("")]
        [Route("showcase")]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAll());
        }

        [HttpGet]
        [Route("product-detail/{id}")]
        public async Task<IActionResult> ProductDetail(Guid id)
        {
            return View(await _productAppService.GetById(id));
        }
    }
}
