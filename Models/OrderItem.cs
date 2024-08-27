using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProjectNamespace.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } // Sipariþ Öðesi ID'si (Primary Key)

        public int OrderId { get; set; } // Sipariþ ID'si (Yabancý Anahtar)

        [ForeignKey("OrderId")]
        public Order Order { get; set; } // Ýlgili Sipariþ

        public int ProductId { get; set; } // Ürün ID'si (Yabancý Anahtar)

        [ForeignKey("ProductId")]
        public Product Product { get; set; } // Ýlgili Ürün

        [Required]
        public int Quantity { get; set; } // Ürün Miktarý

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } // Ürünün Birim Fiyatý
    }
}
