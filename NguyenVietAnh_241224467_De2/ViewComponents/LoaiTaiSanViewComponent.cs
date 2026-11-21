using Microsoft.AspNetCore.Mvc;
using NguyenVietAnh_241224467_De2.Models;
namespace NguyenVietAnh_241224467_De2.ViewComponents
{
    public class LoaiTaiSanViewComponent:ViewComponent
    {
        private readonly QltaiSanContext db;
        public LoaiTaiSanViewComponent(QltaiSanContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiTaiSans = db.LoaiTaiSans.ToList();
            return View("RenderLoaiTaiSan", loaiTaiSans);
        }
    }
}
