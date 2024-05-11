using Microsoft.AspNetCore.Mvc;
using TestBackend.Domain.Entities;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger) : ControllerBase
    {
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Id = index,
                Pku = $"Product {index}",
            }).ToArray();
        }
    }
}