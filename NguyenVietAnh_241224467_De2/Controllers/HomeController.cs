using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenVietAnh_241224467_De2.Models;
using System.Diagnostics;

namespace NguyenVietAnh_241224467_De2.Controllers
{

    public class HomeController : Controller
    {
        private readonly QltaiSanContext db;
        public HomeController(QltaiSanContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var taiSans = db.TaiSans.Where(t=>t.NguyenGia>=20).ToList();
            return View(taiSans);
        }
        public IActionResult TaiSanTheoLoai(int maloai)
        {
            var taiSans = db.TaiSans.Where(t=>t.MaLoai==maloai).ToList();
            return PartialView("TaiSanTheoLoai", taiSans);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taiSan = db.TaiSans.Find(id);
            if (taiSan == null)
            {
                return NotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiTaiSans, "MaLoai", "TenLoai");
            return View(taiSan);
        }
        [HttpPost]
        public IActionResult Edit(TaiSan taiSan)
        {
            ModelState.Remove("MaLoaiNavigation");
            if (ModelState.IsValid)
            {
                db.TaiSans.Update(taiSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiTaiSans, "MaLoai", "TenLoai");
            return View(taiSan);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
