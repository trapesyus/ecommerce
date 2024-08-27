using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProjectNamespace.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; } // Sepet Öðesi ID'si (Primary Key)

        public int CartId { get; set; } // Sepet ID'si (Yabancý Anahtar)

        [ForeignKey("CartId")]
        public Cart Cart { get; set; } // Ýlgili Sepet

        public int ProductId { get; set; } // Ürün ID'si (Yabancý Anahtar)

        [ForeignKey("ProductId")]
        public Product Product { get; set; } // Ýlgili Ürün

        [Required]
        public int Quantity { get; set; } // Ürün Miktarý
    }
}
