using DoAnShopBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnShopBanGiay.Controllers
{
    public class GiohangController : Controller
    {
        dbShopBanGiayDataContext data = new dbShopBanGiayDataContext();
        // lấy giỏ hàng
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        // thêm hàng vào giỏ
        public ActionResult ThemGiohang(int iMagiay, string strURL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            // kiểm tra sách này tồn tại trong session ["Giohang "] chưa
            Giohang sanpham = lstGiohang.Find(n => n.iMagiay == iMagiay);
            if (sanpham == null)
            {
                sanpham = new Giohang(iMagiay);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        // tổn số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.iSoluong);
            }
            return iTongSoLuong;
        }
        // tính tổng tiền
        private double TongTien()
        {
            double iTongTien = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongTien = lstGiohang.Sum(n => n.dThanhtien);
            }
            return iTongTien;
        }
        // GET: Giohang
        public ActionResult Giohang()
        {
            List<Giohang> LstGiohang = Laygiohang();
            if (LstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "ShoesStore");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(LstGiohang);
        }
    }
}