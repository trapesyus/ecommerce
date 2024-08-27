using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommercedotnet.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController : ControllerBase
{
    private readonly YourDbContext _context;

    public CartController(YourDbContext context)
    {
        _context = context;
    }

  
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
    {
        var userId = User.Identity.Name;
        return await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync(); 
    }

    [HttpPost]
    public async Task<ActionResult<CartItem>> AddToCart([FromBody] CartItem cartItem)
    {
        cartItem.UserId = User.Identity.Name;
        _context.CartItems.Add(cartItem);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCartItems), new { id = cartItem.Id }, cartItem);
    }
}
