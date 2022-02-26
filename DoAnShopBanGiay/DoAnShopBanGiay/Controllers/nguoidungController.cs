using DoAnShopBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnShopBanGiay.Controllers
{
    public class nguoidungController : Controller
    {
        dbShopBanGiayDataContext db = new dbShopBanGiayDataContext();
        // GET: nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        // hàm đăng kí nhận dữ liệu từ trang Dangki và thực hiện việc tạo mới dl 

        [HttpPost]
        public ActionResult Dangky(FormCollection collection,KHACHHANG kh)
        {
            
            //gán các giá trị người dùng nhập liệu cho các biến
            var hoten = collection["HotenKH"];
            var tendn = collection["tenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var diachi = collection["Diachi"];
            var emai = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";

            }
            else if(String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "phải nhập mật khẩu ";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "phải nhập lại mật khẩu";
            }
             if (String.IsNullOrEmpty(emai))
            {
                ViewData["Loi5"] = "Email không được bỏ trống ";
            }
             if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "phải nhập số điện thoại";
            }
            else
            {
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = emai;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        public ActionResult Dangnhap(FormCollection collection, KHACHHANG kh)
        {
            //gán các giá trị người dùng nhập liệu cho các biến
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "phải nhập mật khẩu";
            }
            else
            {
                 kh = db.KHACHHANGs.SingleOrDefault( n => n.Taikhoan == tendn && n.Matkhau == matkhau);
            }
            if (kh != null)
            {
                ViewBag.Thongbao = "chúc mừng bạn đã đăng nhập thành công";
                Session["Taikhoan"] = kh;
            }
            else
            {
                ViewBag.Thongbao = "tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();

        }
    }
}