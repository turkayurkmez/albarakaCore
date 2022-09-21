using introRestAPI.Models;
using introRestAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace introRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            //  ProductService productService = new ProductService();
            var products = productService.GetProducts();
            return Ok(products);

        }
        [HttpGet("[action]/{name}")]
        public IActionResult Search(string name)
        {
            return Ok(new Product { Id = 1, Name = "Test", Description = "Test", Price = 1 });
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(new Product { Id = 1, Name = "Test", Description = "Test", Price = 1 });

        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                //ürünü ekle
                return CreatedAtAction(nameof(GetProductById), routeValues: new { id = 1 }, null);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            //eğer belirtilen id'de ürün yoksa: Notfound
            if (productIsNotFound(id))
            {


                if (ModelState.IsValid)
                {
                    //ürün güncellendi...
                    return Ok();
                }

                return BadRequest(ModelState);
            }
            return NotFound();
        }

        private bool productIsNotFound(int id)
        {
            return false;
        }
    }
}
