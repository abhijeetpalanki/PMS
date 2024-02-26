using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.API.Data;
using PMS.API.Models;

namespace PMS.API.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class ProductsController : Controller
	{
		public readonly PMSDbContext _context;

        public ProductsController(PMSDbContext context)
        {
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var products = await _context.Products.ToListAsync();

			return Ok(products);
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct([FromBody] Product product)
		{
			product.ProductId = Guid.NewGuid();

			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();

			return Ok(product);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetProduct(Guid id)
		{
			var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
			if (product == null) { return NotFound(); }

			return Ok(product);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> EditProduct([FromRoute] Guid id, Product updatedProduct)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null) { return  NotFound(); }

			product.ProductName = updatedProduct.ProductName;
			product.ProductType = updatedProduct.ProductType;
			product.ProductColor = updatedProduct.ProductColor;
			product.ProductPrice = updatedProduct.ProductPrice;

			await _context.SaveChangesAsync();

			return Ok(product);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteProduct(Guid id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null) { return NotFound(); }

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();

			return Ok(product);
		}
	}
}
