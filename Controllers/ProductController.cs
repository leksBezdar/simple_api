using Microsoft.AspNetCore.Mvc;
using TestAPI.models;
using TestAPI.services;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductModel> GetOne(int id)
        {
            var product = _productService.GetOne(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductModel> Add(ProductModel product)
        {
            _productService.Add(product);
            return CreatedAtAction(nameof(GetOne), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ProductModel product)
        {
            if (product.Id != id)
            {
                return BadRequest();
            }
            _productService.Update(id, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}
