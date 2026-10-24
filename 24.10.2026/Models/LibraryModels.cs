using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTV_CodeFirst.Models
{
    public class TacGia
    {
        [Key]
        public int MaTacGia { get; set; }
        [Required]
        [StringLength(100)]
        public string TenTacGia { get; set; } = string.Empty;
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public ICollection<Sach> Sachs { get; set; } = new List<Sach>();
    }

    public class TheLoai
    {
        [Key]
        public int MaTheLoai { get; set; }
        [Required]
        [StringLength(100)]
        public string TenTheLoai { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        public ICollection<Sach> Sachs { get; set; } = new List<Sach>();
    }

    public class Sach
    {
        [Key]
        public string MaSach { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string TenSach { get; set; } = string.Empty;
        public int NamXuatBan { get; set; }
        public int SoLuong { get; set; }
        [ForeignKey(nameof(TacGia))]
        public int MaTacGia { get; set; }
        public TacGia? TacGia { get; set; }
        [ForeignKey(nameof(TheLoai))]
        public int MaTheLoai { get; set; }
        public TheLoai? TheLoai { get; set; }
    }
}
