using System;
using System.Collections.Generic;
using System.Linq;

namespace HoGiaHuy_Excercise
{
    public class SinhVien
    {
        public string tenSinhVien { get; set; }
        public double diemTrungBinh { get; set; }
    }
    public class Khoa
    {
        public string tenKhoa { get; set; }
        public List<SinhVien> DanhSachSinhVien { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Khoa> DanhSachKhoa = new List<Khoa>
            {
               new Khoa
            {
                tenKhoa = "Khoa Cong nghe thong tin",
                DanhSachSinhVien = new List<SinhVien>
                {
                    new SinhVien { tenSinhVien = "Nguyen Cong Hung", diemTrungBinh = 8.5 },
                    new SinhVien { tenSinhVien = "Trinh Duong Thi", diemTrungBinh = 6.8 },
                    new SinhVien { tenSinhVien = "Dao Bao Quoc", diemTrungBinh = 7.2 }
                }
            },
                new Khoa
            {
                tenKhoa = "Khoa Kinh Te",
                DanhSachSinhVien = new List<SinhVien>
                {
                    new SinhVien { tenSinhVien = "Tran Van Khoa", diemTrungBinh = 6.5 },
                    new SinhVien { tenSinhVien = "Pham Van Bao", diemTrungBinh = 8.8 },
                    new SinhVien { tenSinhVien = "Le Van Cuong", diemTrungBinh = 9.2 }
                }
              },
            };
            Console.WriteLine("Danh sach sinh vien theo khoa, xep theo ten: ");
            foreach (var khoa in DanhSachKhoa)
            {
                Console.WriteLine($"Khoa: {khoa.tenKhoa}");
                var danhSachTheoTen = khoa.DanhSachSinhVien.OrderBy(sv => sv.tenSinhVien);
                foreach (var sinhVien in danhSachTheoTen)
                {
                    Console.WriteLine($"\t{sinhVien.tenSinhVien} - Diem TB:{sinhVien.diemTrungBinh}");
                }
            }
            Console.WriteLine("Danh sach sinh vien co diem Trung Binh > 7 va < 4: ");
            var danhSachTheoTB = DanhSachKhoa.SelectMany(k => k.DanhSachSinhVien)
                                                        .Where(sv => sv.diemTrungBinh > 7 || sv.diemTrungBinh < 4);
            foreach (var sinhVien in danhSachTheoTB)
            {
                Console.WriteLine($"\t{sinhVien.tenSinhVien} - Diem TB: {sinhVien.diemTrungBinh}");
            }
            Console.WriteLine("Danh Sach Nhung Sinh Vien co ten 'Khoa'");
            var sinhvienTenKhoa = DanhSachKhoa.SelectMany(k => k.DanhSachSinhVien)
                                                                        .FirstOrDefault(sv => sv.tenSinhVien.Contains("Khoa"));
            if (sinhvienTenKhoa != null)
            {
                Console.WriteLine($"Co sinh vien ten {sinhvienTenKhoa.tenSinhVien} trong danh sach ");

            }
            else
            {
                Console.WriteLine("Khong co sinh vien nao ten 'Khoa' trong danh sach");
            }
            Console.WriteLine("\n Danh sach sinh vien co thong tin khoa:");
            var danhSachCoKhoa = DanhSachKhoa.SelectMany(k => k.DanhSachSinhVien.Select(sv => new { TenSinhVien = sv.tenSinhVien, TenKhoa = k.tenKhoa, DiemTrungBinh = sv.diemTrungBinh }));
            foreach (var sinhVien in danhSachCoKhoa)
            {
                Console.WriteLine($"{sinhVien.TenSinhVien} - Khoa: {sinhVien.TenKhoa} - Diem TB: {sinhVien.DiemTrungBinh}");
            }

            Console.WriteLine("\nSinh vien gioi nhat:");
            var DanhSachGioiNhat = DanhSachKhoa.SelectMany(k => k.DanhSachSinhVien)
                                                            .OrderByDescending(sv => sv.diemTrungBinh)
                                                            .FirstOrDefault();
            if (DanhSachGioiNhat != null)
            {
                Console.WriteLine($"{DanhSachGioiNhat.tenSinhVien} - Diem TB: {DanhSachGioiNhat.diemTrungBinh}");
            }
            else
            {
                Console.WriteLine("Khong co sinh vien nao trong danh sach");
            }
            Console.ReadKey();
        }
    }
}
