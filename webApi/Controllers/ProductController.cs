using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _myProductContext;
        public ProductController(ProductContext myProductContext)
        {
            _myProductContext = myProductContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _myProductContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("get-product-by-id")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await _myProductContext.Products.FindAsync(id);
            return Ok(product);
        }

        [HttpPost]
        [Route("Add_product")]
        public async Task<IActionResult> PostAsync(Product product)
        {
            _myProductContext.Products.Add(product);
            await _myProductContext.SaveChangesAsync();
            return Created($"/get-cake-by-id?id={product.Id}", product);
        }

        [HttpPut]
        [Route("Update_product")]
        public async Task<IActionResult> PutAsync(Product ProductToUpdate)
        {
            _myProductContext.Products.Update(ProductToUpdate);
            await _myProductContext.SaveChangesAsync();
            return NoContent();
        }

        [Route("{id} Delete_product")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var productToDelete = await _myProductContext.Products.FindAsync(id);
            if (productToDelete == null)
            {
                return NotFound();
            }
            _myProductContext.Products.Remove(productToDelete);
            await _myProductContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
