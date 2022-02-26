using DoAnShopBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnShopBanGiay.Controllers
{
    public class ShoesStoreController : Controller
    {
        dbShopBanGiayDataContext data = new dbShopBanGiayDataContext();
        private List<GIAY> Laygiaymoi(int count)
        {
            return data.GIAYs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        // GET: ShoesStore
        public ActionResult Index()
        {
            var giaymoi = Laygiaymoi(8);
            return View(giaymoi);
        }
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult Nhasanxuat()
        {
            var nhasanxuat = from nsx in data.NHASANXUATs select nsx;
            return PartialView(nhasanxuat);
        }
        public ActionResult SPTheochude( int id )
        {
            var giay = from s in data.GIAYs where s.MaCD == id select s;
            return View(giay);
        }
        public ActionResult SPTheoNSX(int id)
        {
            var giay = from s in data.GIAYs where s.MaNSX == id select s;
            return View(giay);
        }
        public ActionResult Details(int id)
        {
            var giay = from s in data.GIAYs
                       where s.Magiay == id
                       select s;
            return View(giay.Single());
        }
    }
}