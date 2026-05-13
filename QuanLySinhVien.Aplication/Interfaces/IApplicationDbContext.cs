using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Domain.Entities;

namespace QuanLySinhVien.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<SinhVien> SinhViens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}