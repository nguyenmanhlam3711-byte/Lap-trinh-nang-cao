using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace QuanLySinhVien.Application.Features.Sinhvien.Commands.Create
{
    public class CreateSinhVienCommand : IRequest<string>
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public DateTime NgaySinh { get; set; }
    }
}
