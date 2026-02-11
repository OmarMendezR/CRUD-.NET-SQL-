using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() // ActionResult<IEnumerable<Product>> is the return type of the method, which indicates that it will return an HTTP response containing a collection of Product objects. The ActionResult class allows you to return different types of responses, such as Ok, NotFound, BadRequest, etc., along with the data.
        {
            var products = await _service.GetAllAsync(); // Await the asynchronous operation to get all products from the service
            return Ok(products); // Return an HTTP 200 OK response with the list of products as the response body
        }

        // GET: api/products/{id} get a product by id

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound(); // If the product with the specified ID is not found, return an HTTP 404 Not Found response

            return Ok(product); 
        }

        // POST: api/products create a new product

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            try
            {
                var createdProduct = await _service.CreateAsync(product); // Await the asynchronous operation to create a new product using the service

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdProduct.Id },
                    createdProduct); // Return an HTTP 201 Created response with the location of the newly created product and the product data in the response body
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message); // If an exception occurs during the creation of the product, return an HTTP 400 Bad Request response with the exception message as the response body
            }
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            try // The Update method is an HTTP PUT endpoint that allows updating an existing product. It takes the product ID as a route parameter and the updated product data in the request body. The method uses a try-catch block to handle potential exceptions that may occur during the update process.
            {
                var updated = await _service.UpdateAsync(id, product);

                if (!updated)
                    return NotFound();

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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