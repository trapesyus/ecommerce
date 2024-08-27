using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProjectNamespace.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; } // Sepet ��esi ID'si (Primary Key)

        public int CartId { get; set; } // Sepet ID'si (Yabanc� Anahtar)

        [ForeignKey("CartId")]
        public Cart Cart { get; set; } // �lgili Sepet

        public int ProductId { get; set; } // �r�n ID'si (Yabanc� Anahtar)

        [ForeignKey("ProductId")]
        public Product Product { get; set; } // �lgili �r�n

        [Required]
        public int Quantity { get; set; } // �r�n Miktar�
    }
}
