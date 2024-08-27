using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommercedotnet.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Kullanýcý ID'si (Primary Key)

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } // Kullanýcýnýn Adý


        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; } // Kullanýcýnýn E-posta Adresi

        [Required]
        [StringLength(200)]


        public string PasswordHash { get; set; } // Þifre Hash'i




        public DateTime CreatedAt { get; set; } // Kullanýcýnýn Oluþturulma Tarihi

        public DateTime UpdatedAt { get; set; } // Kullanýcýnýn Son Güncellenme Tarihi
     
        // Kullanýcýnýn Rollerini veya Gruplarýný içerebilir
        // Örneðin: public ICollection<UserRole> Roles { get; set; }
    }
}
