using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourProjectNamespace.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; } // Sepet ID'si (Primary Key)

        public int UserId { get; set; } // Kullan�c� ID'si (Yabanc� Anahtar)

        public User User { get; set; } // Sepet Sahibi Kullan�c�

        public ICollection<CartItem> CartItems { get; set; } // Sepetteki �r�nler
    }
}
