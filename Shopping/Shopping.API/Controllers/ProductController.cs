using Microsoft.AspNetCore.Mvc;
using Shopping.API.Models;
using Shopping.API.Data;
using MongoDB.Driver;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ProductContext _productContext;
        private readonly ILogger<ProductController> logger;

        public ProductController(ProductContext productContext, ILogger<ProductController> logger)
        {
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts() {
           
            return await _productContext.Products.Find(p => true).ToListAsync();
        }
    }
}
