using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPIProject.Models;

namespace MyFirstWebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static List<Product> _products = new() {
        new () { Id = 1, Name = "Laptop", Price = 1000.00m, Category = "Electronics"},
        new () { Id = 2, Name = "Desktop", Price = 2000.00m, Category = "Electronics"},
        new () { Id = 3, Name = "Mobile", Price = 3000.00m, Category = "Electronics"},
    };

    /// <summary>
    ///  Get list of products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return _products;
    }

    /// <summary>
    /// Get product by product id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    /// <summary>
    /// Add new product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<Product> PostProduct(Product product)
    {
        _products.Add(product);
        // return CreatedAtAction(nameof(GetProduct), new { Id = product.Id });
        return Created();
    }

    /// <summary>
    /// Update a product by product id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        var existingProduct = _products.FirstOrDefault(p => p.Id == id);

        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = product.Name;
        existingProduct.Category = product.Category;
        existingProduct.Price = product.Price;

        return NoContent();
    }

    /// <summary>
    /// Delete a product by product id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        _products.Remove(product);
        return NoContent();
    }
}