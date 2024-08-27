using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProjectNamespace.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Kullanýcý ID'si (Primary Key)

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } // Kullanýcýnýn Adý

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } // Kullanýcýnýn Soyadý

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; } // Kullanýcýnýn E-posta Adresi

        [Required]
        [StringLength(200)]
        public string PasswordHash { get; set; } // Þifre Hash'i

        public DateTime DateOfBirth { get; set; } // Doðum Tarihi

        public string PhoneNumber { get; set; } // Telefon Numarasý

        public string Address { get; set; } // Kullanýcýnýn Adresi

        public bool IsActive { get; set; } // Kullanýcýnýn Aktif Durumu

        public DateTime CreatedAt { get; set; } // Kullanýcýnýn Oluþturulma Tarihi

        public DateTime UpdatedAt { get; set; } // Kullanýcýnýn Son Güncellenme Tarihi

        // Kullanýcýnýn Rollerini veya Gruplarýný içerebilir
        // Örneðin: public ICollection<UserRole> Roles { get; set; }
    }
}
