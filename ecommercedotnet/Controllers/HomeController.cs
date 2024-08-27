using ecommercedotnet.Abstract;
using ecommercedotnet.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ecommercedotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Index(string loginEmail, string loginPassword)
        {
            var userList = _userService.GetUsers();
            var user = userList.FirstOrDefault(loginController => loginController.Email == loginEmail && loginController.PasswordHash == loginPassword);
            if (ModelState.IsValid)
            {
                // Basit bir kimlik doðrulama örneði
                if (user != null)
                {
                    Console.WriteLine("Giriþ Baþarýlýýýýð");

                    // Kullanýcý doðrulandýysa, claim'leri oluþturuyoruz
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName), // Kullanýcý adý claim olarak ekleniyor
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    // Diðer claim'ler
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        // Authentication özelliklerini yapýlandýrabilirsiniz
                    };
                    // Kullanýcýyý giriþ yapmýþ olarak iþaretliyoruz
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);
                    // Baþarýlý giriþ iþlemi
                    return RedirectToAction("Privacy", "Home");
                }
                else
                {
                    Console.WriteLine("Giriþ Baþarýsýýýz");
                    // Baþarýsýz giriþ iþlemi
                    ModelState.AddModelError(string.Empty, "Geçersiz e-posta veya þifre.");
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
