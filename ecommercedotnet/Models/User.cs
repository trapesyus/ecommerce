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
        public int Id { get; set; } // Kullan�c� ID'si (Primary Key)

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } // Kullan�c�n�n Ad�


        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; } // Kullan�c�n�n E-posta Adresi

        [Required]
        [StringLength(200)]


        public string PasswordHash { get; set; } // �ifre Hash'i




        public DateTime CreatedAt { get; set; } // Kullan�c�n�n Olu�turulma Tarihi

        public DateTime UpdatedAt { get; set; } // Kullan�c�n�n Son G�ncellenme Tarihi
     
        // Kullan�c�n�n Rollerini veya Gruplar�n� i�erebilir
        // �rne�in: public ICollection<UserRole> Roles { get; set; }
    }
}
