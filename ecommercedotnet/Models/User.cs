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
        public int Id { get; set; } // Kullanıcı ID'si (Primary Key)

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } // Kullanıcının Adı


        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; } // Kullanıcının E-posta Adresi

        [Required]
        [StringLength(200)]


        public string PasswordHash { get; set; } // Şifre Hash'i




        public DateTime CreatedAt { get; set; } // Kullanıcının Oluşturulma Tarihi

        public DateTime UpdatedAt { get; set; } // Kullanıcının Son Güncellenme Tarihi
     
        // Kullanıcının Rollerini veya Gruplarını içerebilir
        // Örneğin: public ICollection<UserRole> Roles { get; set; }
    }
}
