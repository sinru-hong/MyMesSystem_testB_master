using System.Collections;
using test_B.Models;
using test_B.ModelServices;

namespace test_B.Services
{
    public class ProductService
    {
        //public List<Product> GetFakeProducts()
        //{
        //    // 模擬從資料庫拿回來的資料
        //    return new List<Product>
        //    {
        //        new Product { ProductID = "A01", ProductName = "機台A", Price = 1000 },
        //        new Product { ProductID = "B02", ProductName = "機台B", Price = 2000 }
        //    };
        //}

        private readonly ProductModelService _modelService;

        // 建構子：跟系統說我需要這個 Service
        public ProductService(ProductModelService modelService)
        {
            _modelService = modelService;
        }

        public List<Product> GetFakeProducts()
        {
            // 使用注入進來的物件實體
            List<Product> returnList = _modelService.GetProductsFromDb();
            return returnList;
        }

        public IList GetComplexProductList()
        {
            // 這裡可以直接回傳 ModelService 抓回來的 Hashtable 清單
            return _modelService.GetProductsAsHashTable();
        }
    }
}
