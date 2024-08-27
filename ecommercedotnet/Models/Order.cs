using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecommercedotnet.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } // Sipari� ID'si (Primary Key)

        public int UserId { get; set; } // Kullan�c� ID'si (Yabanc� Anahtar)

        public User User { get; set; } // Sipari� Sahibi Kullan�c�

        public DateTime OrderDate { get; set; } // Sipari� Tarihi

        public string ShippingAddress { get; set; } // Teslimat Adresi

        public decimal TotalAmount { get; set; } // Toplam Sipari� Tutar�

        public ICollection<OrderItem> OrderItems { get; set; } // Sipari�teki �r�nler
    }
}
