using Microsoft.AspNetCore.Mvc;
using PCTASK.Domain.Interfaces;
using PCTASK.Domain.Models.Product;

namespace PCTASK.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _productService.AddProduct(model);

            return Ok(model);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _productService.UpdateProduct(model);

            return Ok(model);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            if (id == 0)
                return BadRequest("Invalid id");
            var product = _productService.GetProduct(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetِAllProducts([FromQuery] ProductFilter filter)
        {
            var products = _productService.GetAllProducts(filter);
            return Ok(products);
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveProduct(int id)
        {
            if (id == 0)
                return BadRequest("Invalid id");

            _productService.RemoveProduct(id);

            return Ok();
        }
    }
}