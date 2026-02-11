using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTOs;
using PruebaTecnica.Models;
using PruebaTecnica.Service.Interfaces;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service) // The constructor of the ProductsController class takes an IProductService as a parameter and assigns it to the private readonly field _service. This allows the controller to use the service to perform operations related to products, such as retrieving all products from the database.
        {
            _service = service;
        }

        // GET: api/products  get all products in the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _service.GetAllAsync();

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CreatedAt = p.CreateAt
            });

            return Ok(result);
        }


        // GET: api/products/{id} get a product by id

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var result = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CreatedAt = product.CreateAt
            };

            return Ok(result);
        }


        // POST: api/products create a new product

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };

            var createdProduct = await _service.CreateAsync(product);

            var result = new ProductDto
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                CreatedAt = createdProduct.CreateAt
            };

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };

            var updated = await _service.UpdateAsync(id, product);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) // The Delete method is an HTTP DELETE endpoint that allows deleting a product by its ID. It takes the product ID as a route parameter and uses the service to perform the deletion. If the product is successfully deleted, it returns an HTTP 204 No Content response. If the product with the specified ID is not found, it returns an HTTP 404 Not Found response.
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}