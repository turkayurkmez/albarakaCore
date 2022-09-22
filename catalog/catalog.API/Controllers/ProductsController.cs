
using catalog.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }



        /*YAGNI
         * 
         * You ain't gonna need it! 
         */
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            //business'dan bana gereken nesneyi kullanarak ürünleri getir ve döndürür.
            var products = productService.GetProducts();
            return Ok(products);
        }
    }
}
