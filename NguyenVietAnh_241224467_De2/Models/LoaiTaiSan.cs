using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NguyenVietAnh_241224467_De2.Models;

public partial class LoaiTaiSan
{
    [Key]
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<TaiSan> TaiSans { get; set; } = new List<TaiSan>();
}
