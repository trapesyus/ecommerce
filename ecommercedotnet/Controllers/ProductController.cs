using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Buraya ekledik
using System.Collections.Generic;
using System.Threading.Tasks;
using ecommercedotnet.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly YourDbContext _context;

    public ProductController(YourDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync(); // ToListAsync burada kullanılabilir
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }
}
