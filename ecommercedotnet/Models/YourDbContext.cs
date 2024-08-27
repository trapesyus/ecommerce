using Microsoft.EntityFrameworkCore;

namespace ecommercedotnet.Models
{
    public class YourDbContext : DbContext
    {
        private static IConfiguration _configuration; // Statik alan

        static YourDbContext()
        {
            // Statik yapýlandýrýcý içinde yapýlandýrma oluþtur
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }


        string connectionString = _configuration.GetConnectionString("DefaultConnection");



        //static readonly string connectionString = "server=45.84.189.34\\localhost; database=bilgegul_netcorelaw; user=bilgegul_er; password=Gara4ever*";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
