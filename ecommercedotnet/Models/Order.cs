using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecommercedotnet.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } // Sipariþ ID'si (Primary Key)

        public int UserId { get; set; } // Kullanýcý ID'si (Yabancý Anahtar)

        public User User { get; set; } // Sipariþ Sahibi Kullanýcý

        public DateTime OrderDate { get; set; } // Sipariþ Tarihi

        public string ShippingAddress { get; set; } // Teslimat Adresi

        public decimal TotalAmount { get; set; } // Toplam Sipariþ Tutarý

        public ICollection<OrderItem> OrderItems { get; set; } // Sipariþteki Ürünler
    }
}
