using ecommercedotnet.Abstract;
using ecommercedotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ecommercedotnet.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUserService _userService;

        public SignUpController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: SignUp
        [HttpPost]
        public async Task<IActionResult> SignUp(string userName, string email, string password)
        {
            var newUser = new User
            {
                UserName = userName,
                Email = email,
                PasswordHash = password, // Bu gerçek uygulamada hash'lenmiş olmalı
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _userService.AddUser(newUser);

            // Başarılı kayıt işleminden sonra anasayfaya yönlendir
            return RedirectToAction("Privacy", "Home");
        }
    }
}
