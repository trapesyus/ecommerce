using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourProjectNamespace.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; } // Sepet ID'si (Primary Key)

        public int UserId { get; set; } // Kullanýcý ID'si (Yabancý Anahtar)

        public User User { get; set; } // Sepet Sahibi Kullanýcý

        public ICollection<CartItem> CartItems { get; set; } // Sepetteki Ürünler
    }
}
