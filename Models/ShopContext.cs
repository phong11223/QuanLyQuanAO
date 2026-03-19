using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace QuanLyQuanAO.Models
{
   
        // 1. Khai báo bảng Quần áo
        public class Product
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            public string Category { get; set; } // Áo, Quần, Phụ kiện...
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }

        // 2. Cấu hình kết nối SQL Server
        public class ShopContext : DbContext
        {
            public DbSet<Product> Products { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                // Tên Server lấy từ hình bạn gửi: TRANTHINHPHONG\\SQLEXPRESS
                // Database mới tự đặt tên là: ShopOnlineDB
                options.UseSqlServer("Server=TRANTHINHPHONG\\SQLEXPRESS;Database=ShopOnlineDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
}
