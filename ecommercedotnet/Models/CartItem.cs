using System.ComponentModel.DataAnnotations;

namespace ecommercedotnet.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; } // Ürün adedi
    }
}
