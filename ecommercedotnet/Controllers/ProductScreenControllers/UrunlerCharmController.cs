using ecommercedotnet.Abstract;
using ecommercedotnet.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ecommercedotnet.Controllers.ProductScreenControllers
{
    public class UrunlerCharmController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IUserService _userService;

        public UrunlerCharmController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult UrunlerCharm()
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
                // Basit bir kimlik doğrulama örneği
                if (user != null)
                {
                    Console.WriteLine("Giriş Başarılıııığ");

                    // Kullanıcı doğrulandıysa, claim'leri oluşturuyoruz
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName), // Kullanıcı adı claim olarak ekleniyor
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    // Diğer claim'ler
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        // Authentication özelliklerini yapılandırabilirsiniz
                    };
                    // Kullanıcıyı giriş yapmış olarak işaretliyoruz
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);
                    // Başarılı giriş işlemi
                    return RedirectToAction("UrunlerCharm", "UrunlerCharm");
                }
                else
                {
                    Console.WriteLine("Giriş Başarısııız");
                    // Başarısız giriş işlemi
                    ModelState.AddModelError(string.Empty, "Geçersiz e-posta veya şifre.");
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
