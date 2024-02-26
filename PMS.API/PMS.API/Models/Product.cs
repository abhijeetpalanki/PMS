using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.API.Models
{
	public class Product
	{
		[Key]
        public Guid ProductId { get; set; }

		[Column(TypeName = "nvarchar(100)")]
		public string ProductName { get; set; } = "";

		[Column(TypeName = "nvarchar(100)")]
		public string ProductType { get; set; } = "";

		[Column(TypeName = "nvarchar(50)")]
		public string ProductColor { get; set; } = "";

		[Column(TypeName = "decimal(18,4)")]
		public decimal ProductPrice { get; set; } = 0;
	}
}
