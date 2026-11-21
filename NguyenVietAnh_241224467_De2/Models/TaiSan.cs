using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenVietAnh_241224467_De2.Models;

public partial class TaiSan
{
    [Key]
    public int MaTs { get; set; }

    public int MaLoai { get; set; }
    [Required(ErrorMessage ="Ten tai san ko dc de trong")]
    public string TenTs { get; set; } = null!;
    [Required(ErrorMessage = "Gia ko dc de trong")]
    [Range(1,2000,ErrorMessage ="Gia phai nam trong khoang tu 1 den 2000")]
    public decimal? NguyenGia { get; set; }
    [Required(ErrorMessage = "Anh ko dc de trong")]
    [RegularExpression(@"^.*\.(jpg|jpeg|png|webp)$",ErrorMessage ="Anh phai co duoi jpg jpeg png webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan MaLoaiNavigation { get; set; } = null!;
}
