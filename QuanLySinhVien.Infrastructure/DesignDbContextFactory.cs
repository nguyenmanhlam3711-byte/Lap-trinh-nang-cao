using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QuanLySinhVien.Infrastructure.Persistence;

namespace QuanLySinhVien.Infrastructure
{
    public class DesignDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Điền trực tiếp chuỗi kết nối của máy bạn vào đây
            optionsBuilder.UseSqlServer("Server=PC\\SQLEXPRESS;Database=QuanLySinhVien;Trusted_Connection=True;TrustServerCertificate=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}