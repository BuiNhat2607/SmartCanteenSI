using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SmartCanteenSI.Models.Data
{
    public class CartOFS
    {
        public int dishID { get; set; }
        public string tenMon { get; set; }
        [Display(Name = "Suat ngay hom nay")]
        public int soLuongChon { get; set; }
        public int? soLuongTon { get; set; }
        public string hinh { get; set; }
    }
}