using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourProjectNamespace.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; } // Kategori ID'si (Primary Key)

		[Required]
		[StringLength(100)]
		public string Name { get; set; } // Kategori Ad�

		public ICollection<Product> Products { get; set; } // Bu Kategorideki �r�nler
	}
}
