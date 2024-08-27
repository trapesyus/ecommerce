using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProjectNamespace.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } // Sipari� ��esi ID'si (Primary Key)

        public int OrderId { get; set; } // Sipari� ID'si (Yabanc� Anahtar)

        [ForeignKey("OrderId")]
        public Order Order { get; set; } // �lgili Sipari�

        public int ProductId { get; set; } // �r�n ID'si (Yabanc� Anahtar)

        [ForeignKey("ProductId")]
        public Product Product { get; set; } // �lgili �r�n

        [Required]
        public int Quantity { get; set; } // �r�n Miktar�

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } // �r�n�n Birim Fiyat�
    }
}
