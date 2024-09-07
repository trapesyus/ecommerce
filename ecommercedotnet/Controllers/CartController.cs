using ecommercedotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ecommercedotnet.Controllers
{
    public class CartController : Controller
    {
        // Sepeti görüntüleme
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        // Sepete ürün ekleme
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            // Ürünü bul
            Product product = GetProductById(productId); // Bu kısımda veri kaynağından ürünü almanız gerekiyor

            if (product == null)
            {
                return NotFound();
            }

            // Sepeti session'dan al veya yeni bir liste oluştur
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Sepette ürün zaten var mı kontrol et
            CartItem existingItem = cart.Find(x => x.Product.Id == productId);
            if (existingItem != null)
            {
                // Ürün zaten varsa adetini artır
                existingItem.Quantity += quantity;
            }
            else
            {
                // Yeni ürün ekle
                cart.Add(new CartItem { Product = product, Quantity = quantity });
            }

            // Sepeti güncelle ve session'a kaydet
            HttpContext.Session.Set("Cart", cart);

            return RedirectToAction("Cart");
        }

        // Sepetten ürün silme
        public IActionResult RemoveFromCart(int productId)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Ürünü sepetten bul ve kaldır
            CartItem itemToRemove = cart.Find(x => x.Product.Id == productId);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
            }

            // Sepeti güncelle ve session'a kaydet
            HttpContext.Session.Set("Cart", cart);

            return RedirectToAction("Index");
        }

        // Sepeti temizleme
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }

        // Bu, örnek olarak bir ürün getirme fonksiyonudur. Veri kaynağından ürün çekmek için bunu kendi veritabanınıza entegre edin.
        private Product GetProductById(int id)
        {
            // Örnek ürünler, bunu kendi veri kaynağınıza göre güncelleyin
            return new Product { Id = id, Name = "Example Product", Price = 10.99m, Description = "Example Description" };
        }
    }
}
