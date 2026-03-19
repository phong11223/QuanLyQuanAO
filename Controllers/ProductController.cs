using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAO.Models;

namespace QuanLyQuanAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Lấy danh sách quần áo
        [HttpGet]
        public IActionResult Get()
        {
            using var db = new ShopContext();
            return Ok(db.Products.ToList());
        }

        // Thêm mới (POST)
        [HttpPost]
        public IActionResult Post(Product p)
        {
            using var db = new ShopContext();
            db.Products.Add(p);
            db.SaveChanges();
            return Ok(p);
        }

        // Cập nhật (PUT)
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product p)
        {
            using var db = new ShopContext();
            var item = db.Products.Find(id);
            if (item == null) return NotFound();

            item.Name = p.Name;
            item.Category = p.Category;
            item.Price = p.Price;
            item.Stock = p.Stock;

            db.SaveChanges();
            return Ok("Cập nhật thành công!");
        }

        // Xóa (DELETE)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var db = new ShopContext();
            var item = db.Products.Find(id);
            if (item == null) return NotFound();

            db.Products.Remove(item);
            db.SaveChanges();
            return Ok("Đã xóa!");
        }
    }
}
