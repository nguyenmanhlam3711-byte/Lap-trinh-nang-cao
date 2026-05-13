using System;
using System.Collections.Generic;
using QuanLySinhVien.Domain.Entities;
using MediatR;
using QuanLySinhVien.Application.Interfaces;
using QuanLySinhVien.Domain.Entities;

namespace QuanLySinhVien.Application.Features.Sinhvien.Commands.Create
{
    public class CreateSinhVienHandler
        : IRequestHandler<CreateSinhVienCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateSinhVienHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateSinhVienCommand request, CancellationToken cancellationToken)
        {
            var sv = new SinhVien
            {
                MaSV = request.MaSV,
                TenSV = request.TenSV,
                NgaySinh = request.NgaySinh
            };

            _context.SinhViens.Add(sv);
            await _context.SaveChangesAsync(cancellationToken);

            return sv.MaSV;
        }
    }
}