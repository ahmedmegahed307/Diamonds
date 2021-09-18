using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jewellery.Models;
using Jewellery.BL;
using Domains;
using Jewellery.InfraStructure;

namespace MultiKartt.Controllers
{
    public class WishListController : Controller
    {
        IProductService IProduct;
        public WishListController(IProductService service)
        {
            IProduct = service;
        }
        public IActionResult AddToWishList(int id)
        {
            WishListModel wishes = HttpContext.Session.GetObjectFromJson<WishListModel>("wishlist");
            if (wishes == null)
            {
                wishes = new WishListModel();


            }
            TbProduct product = IProduct.GetById(id);

            wishes.ListWish.Add(new WishListData()
            {
                WishListDataId = product.TbProductId,
                ProductName = product.ProductName,
                Image = product.ProductImageName,
                Price = product.ProductPrice
            });

            HttpContext.Session.SetObjectAsJson("wishlist", wishes);
            return Redirect("/WishList/wishlist");
        }
        public IActionResult wishlist()
        {
            WishListModel wishes = HttpContext.Session.GetObjectFromJson<WishListModel>("wishlist") ?? new WishListModel();
            return View(wishes);
        }
       
            public IActionResult RemoveItem(int id)
        {
            WishListModel oShopingCart = HttpContext.Session.GetObjectFromJson<WishListModel>("wishlist");
            oShopingCart.ListWish.Remove(oShopingCart.ListWish.Where(a => a.WishListDataId == id).FirstOrDefault());
            HttpContext.Session.SetObjectAsJson("wishlist", oShopingCart);
            return RedirectToAction("wishlist");
        }
    }
}
