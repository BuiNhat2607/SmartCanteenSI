using SmartCanteenSI.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SmartCanteenSI.Models.Data
{
    public class Cart
    {
        SmartCanteenContext context = new SmartCanteenContext();

        public int dishID { get; set; }

        [Display(Name = "Tên món")]
        public string tenMon { get; set; }
        [Display(Name = "Hình")]
        public string hinh { get; set; }
        [Display(Name = "Giá")]
        public double giaBan { get; set; }
        [Display(Name = "Số lượng")]
        public int soLuong { get; set; }
        [Display(Name = "Thành tiền")]
        public double thanhTien
        {
            get { return soLuong * giaBan; }
        }

        public Cart(int id)
        {
            dishID = id;
            Dish sach = context.Dishes.Single(n => n.DishID == dishID);
            tenMon = sach.DishName;
            hinh = sach.Image;
            giaBan = double.Parse(sach.Price.ToString());
            soLuong = 1;
        }
    }
}