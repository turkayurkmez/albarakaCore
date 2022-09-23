using catalog.API.Filters;
using catalog.Business.DTOs.Requests;
using catalog.Business.Services;
using Microsoft.AspNetCore.Authorization;
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
            var products = await productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await productService.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound(new { message = "Belirtilen id'de bir ürün bulunamadı" });

        }
        [HttpPost]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> Add(CreateProductRequest createProduct)
        {
            if (ModelState.IsValid)
            {
                var id = await productService.AddProduct(createProduct);
                return CreatedAtAction(nameof(GetProductById), new { id = id }, null);

            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        [IsExists]
        public async Task<IActionResult> Update(int id, UpdateProductRequest updateProduct)
        {
            //1. id'li ürün var mı?
            //if (await productService.IsEntityExists(id))
            //{
            if (ModelState.IsValid)
            {
                await productService.UpdateProduct(updateProduct);

                return Ok(updateProduct);

            }
            //ModelState.AddModelError("x", "Haftasonu EFT olmaz");
            return BadRequest(ModelState);
            //}

            //return NotFound();
        }
        [HttpDelete("{id}")]
        [IsExists]
        public async Task<IActionResult> Delete(int id)
        {
            //if (await productService.IsEntityExists(id))
            //{
            await productService.Delete(id);
            return Ok();
            //}
            // return NotFound();
        }
    }
}
