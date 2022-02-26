using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnShopBanGiay.Models
{
    public class Giohang
    {

        // tạo đối tượng data chứa dữ liệu từ models dbshopbangiay đã tạo 
        dbShopBanGiayDataContext data = new dbShopBanGiayDataContext();
        public int iMagiay { set; get; }
        public string sTengiay { set; get;}
        public string sAnhbia { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        // khởi tạo giỏ hàng theo mã giày được truyền vào với số lượng mặc định là 1 
        public Giohang(int Magiay)

        {
            iMagiay = Magiay;
            GIAY giay = data.GIAYs.Single(n => n.Magiay == iMagiay);
            sTengiay = giay.Tengiay;
            sAnhbia = giay.Anhbia;
            dDongia = double.Parse(giay.Giaban.ToString());
            iSoluong = 1;
        }

    }
}