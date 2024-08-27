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
                // Basit bir kimlik do�rulama �rne�i
                if (user != null)
                {
                    Console.WriteLine("Giri� Ba�ar�l�����");

                    // Kullan�c� do�ruland�ysa, claim'leri olu�turuyoruz
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName), // Kullan�c� ad� claim olarak ekleniyor
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    // Di�er claim'ler
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        // Authentication �zelliklerini yap�land�rabilirsiniz
                    };
                    // Kullan�c�y� giri� yapm�� olarak i�aretliyoruz
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);
                    // Ba�ar�l� giri� i�lemi
                    return RedirectToAction("Privacy", "Home");
                }
                else
                {
                    Console.WriteLine("Giri� Ba�ar�s���z");
                    // Ba�ar�s�z giri� i�lemi
                    ModelState.AddModelError(string.Empty, "Ge�ersiz e-posta veya �ifre.");
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
