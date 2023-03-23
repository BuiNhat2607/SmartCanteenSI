using SmartCanteenSI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCanteenSI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        SmartCanteenContext context = new SmartCanteenContext();
        private List<CartOFS> ofsList=new List<CartOFS>();
        public List<Cart> GetCart()
        {
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart == null)
            {
                listCart = new List<Cart>();
                Session["Cart"] = listCart;

            }
            return listCart;
        }
        public ActionResult ThemGioHang(int id, string strURL)
        {
            if (Session["Account"] != null)
            {
                List<Cart> listCart = GetCart();
                Cart item = listCart.Find(n => n.dishID == id);
                if (item == null)
                {
                    item = new Cart(id);
                    listCart.Add(item);
                    return Redirect(strURL);
                }
                else
                {
                    item.soLuong++;

                    return Redirect(strURL);
                }
            }
            else
            {
                return RedirectToAction("LoginPage","Login");
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart != null)
            {
                tsl = listCart.Sum(n => n.soLuong);
            }
            return tsl;
        }
        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart != null)
            {
                tsl = listCart.Count;
            }
            return tsl;
        }
        private double TongTien()
        {
            double tt = 0;
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart != null)
            {
                tt = listCart.Sum(n => n.thanhTien);
            }
            return tt;
        }
        public ActionResult Cart()
        {
            List<Cart> listCart = GetCart();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            return View(listCart);
        }
        public ActionResult CartPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            return PartialView();
        }
        public ActionResult XoaGioHang(int id)
        {
            List<Cart> listCart = GetCart();
            Cart item = listCart.SingleOrDefault(n => n.dishID == id);
            if (item != null)
            {
                listCart.RemoveAll(n => n.dishID == id);
                return RedirectToAction("Cart");

            }
            return RedirectToAction("Cart");
        }
        public ActionResult UpdateCart(int id, FormCollection collection)
        {
            List<Cart> listCart = GetCart();
            Cart item = listCart.SingleOrDefault(n => n.dishID == id);
            Dish dish = context.Dishes.SingleOrDefault(d => d.DishID == id);
            if (item != null)
            {
                int sl = int.Parse(collection["txtSoLg"].ToString());
                if (dish.InStock < sl)
                {
                    ViewBag.Error = "Không đủ số lượng";
                    return RedirectToAction("OutOfStock", "Error");
                }
                else
                {
                    item.soLuong = sl;
                }
            }
            return RedirectToAction("Cart");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<Cart> listCart = GetCart();
            listCart.Clear();
            return RedirectToAction("Cart");
        }


        //// GET: GioHang
        [HttpGet]
        public ActionResult Order()

        {
            if (Session["Account"] == null || Session["Account"].ToString() == "")
            {
                return RedirectToAction("LoginPage", "Login");

            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Cart", "Cart");
            }
            if (ofsList.Count == 0)
            {
                Session["DS"] = null;
            }
            List<Cart> listCart = GetCart();
            foreach(Cart item in listCart)
            {
                Dish d = context.Dishes.SingleOrDefault(x => x.DishID == item.dishID);

                if (d.InStock < item.soLuong)
                {
                    CartOFS ofs = ofsList.Where(o => o.dishID == item.dishID).FirstOrDefault();
                    if (ofs == null)
                    {
                        CartOFS newOFS = new CartOFS
                        {
                            dishID = item.dishID,
                            tenMon = item.tenMon,
                            soLuongChon=item.soLuong,
                            soLuongTon = d.InStock,
                            hinh = item.hinh,
                        };
                        ofsList.Add(newOFS);
                        List<CartOFS> danhsach = ofsList.ToList();
                        Session["DS"] = danhsach;
                    }
                }   
            }
            foreach (CartOFS check in ofsList)
            {
                Dish d = context.Dishes.SingleOrDefault(x => x.DishID == check.dishID);
                if (d.InStock > check.soLuongChon)
                {
                    ofsList.Remove(check);
                }
            }
            ViewBag.Tongsoluong = TongSoLuong();

            ViewBag.Tongtien = TongTien();

            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(listCart);
        }

        public ActionResult Order(FormCollection collection)
        {

            Order order = new Order();
            User kh = (User)Session["Account"];
            Dish d = new Dish();

            List<Cart> gh = GetCart();
            order.UserID = kh.UserID;

            order.Date = DateTime.Now;
            order.Total = TongTien();
            context.Orders.Add(order);
            context.SaveChanges();
            foreach (var item in gh)
            {
                OrderDetail ctdh = new OrderDetail();
                ctdh.OrderID = order.OrderID;
                ctdh.DishID = item.dishID;
                ctdh.Quantity = item.soLuong;
                ctdh.Price = item.giaBan;
                d= context.Dishes.Single(n => n.DishID == item.dishID);
                d.InStock -= ctdh.Quantity;

                context.SaveChanges();

                context.OrderDetails.Add(ctdh);
            }
            context.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("OrderConfirm", "Cart");
        }
        public ActionResult OrderConfirm()
        {
            return View();
        }
    }
}