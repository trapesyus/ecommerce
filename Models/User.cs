using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProjectNamespace.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Kullanıcı ID'si (Primary Key)

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } // Kullanıcının Adı

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } // Kullanıcının Soyadı

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; } // Kullanıcının E-posta Adresi

        [Required]
        [StringLength(200)]
        public string PasswordHash { get; set; } // Şifre Hash'i

        public DateTime DateOfBirth { get; set; } // Doğum Tarihi

        public string PhoneNumber { get; set; } // Telefon Numarası

        public string Address { get; set; } // Kullanıcının Adresi

        public bool IsActive { get; set; } // Kullanıcının Aktif Durumu

        public DateTime CreatedAt { get; set; } // Kullanıcının Oluşturulma Tarihi

        public DateTime UpdatedAt { get; set; } // Kullanıcının Son Güncellenme Tarihi

        // Kullanıcının Rollerini veya Gruplarını içerebilir
        // Örneğin: public ICollection<UserRole> Roles { get; set; }
    }
}
