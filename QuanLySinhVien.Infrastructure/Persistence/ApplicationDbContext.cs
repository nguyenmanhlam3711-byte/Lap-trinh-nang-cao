using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Application.Interfaces;
using QuanLySinhVien.Domain.Entities; // Đảm bảo đã using đúng namespace của SinhVien

namespace QuanLySinhVien.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SinhVien> SinhViens { get; set; }

        // --- ĐÂY LÀ PHẦN BẠN CẦN THÊM VÀO ---
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình MaSV là khóa chính cho bảng SinhVien
            modelBuilder.Entity<SinhVien>()
                .HasKey(s => s.MaSV);

            // Bạn cũng có thể cấu hình thêm độ dài tối đa nếu muốn (tùy chọn)
            modelBuilder.Entity<SinhVien>()
                .Property(s => s.MaSV)
                .HasMaxLength(20);
        }
        // ------------------------------------

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}