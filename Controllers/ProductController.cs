using Microsoft.AspNetCore.Mvc;
using test_B.Services;

namespace test_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly ProductService _service = new ProductService();

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var data = _service.GetFakeProducts();
        //    return Ok(data); // 這會回傳 JSON [ { "productID": "A01", ... } ]
        //}
        private readonly ProductService _service;

        // 由系統自動注入 Service
        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetFakeProducts();
            return Ok(data);
        } 

        [HttpGet("complex")]
        public IActionResult GetComplexData()
        {
            var data = _service.GetComplexProductList();
            return Ok(data); // 雖然是 Hashtable，回傳依然是 [ { "ProductID": "...", "StockQty": 10 }, ... ]
        }
    }
}
