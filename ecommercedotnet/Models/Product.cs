using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommercedotnet.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // �r�n ID'si (Primary Key)

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // �r�n Ad�

        [Required]
        [StringLength(500)]
        public string Description { get; set; } // �r�n A��klamas�

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // �r�n Fiyat�

        [StringLength(255)]
        public string ImageUrl { get; set; } // �r�n G�rsel URL'si

        public int CategoryId { get; set; } // �r�n�n Kategorisi i�in Yabanc� Anahtar

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } // �r�n Kategorisi

        public bool IsAvailable { get; set; } // �r�n�n Stok Durumu
    }
}
