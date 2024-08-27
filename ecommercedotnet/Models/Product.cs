using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommercedotnet.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // Ürün ID'si (Primary Key)

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Ürün Adý

        [Required]
        [StringLength(500)]
        public string Description { get; set; } // Ürün Açýklamasý

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Ürün Fiyatý

        [StringLength(255)]
        public string ImageUrl { get; set; } // Ürün Görsel URL'si

        public int CategoryId { get; set; } // Ürünün Kategorisi için Yabancý Anahtar

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } // Ürün Kategorisi

        public bool IsAvailable { get; set; } // Ürünün Stok Durumu
    }
}
