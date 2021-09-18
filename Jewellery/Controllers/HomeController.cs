using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Jewellery.BL;
using Jewellery.InfraStructure;
using Jewellery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jewellery.Controllers
{
   


public class HomeController : Controller
    {
       
        IProductService IProduct;
        JewelContext ctx;
        public HomeController(IProductService csa, JewelContext context)
        {
            
            IProduct = csa;
            ctx = context;
        }

        public IActionResult Index()
        {
            HomePageViewModel _model = new HomePageViewModel();
            _model.ListSlider = IProduct._slider().ToList();
            _model.ListAllProducts = IProduct.GetAll();
            _model.ListNewProducts = _model.ListAllProducts.Skip(25).Take(8).ToList();
            _model.Instagram = _model.ListAllProducts.Skip(35).Take(10).ToList();
            _model.ListBestSeller = _model.ListAllProducts.Skip(16).Take(8).ToList();
            _model.ListFeatureProducts = _model.ListAllProducts.Take(8).ToList();
            
           //begin count
          
            ViewBag.Rings = (int)Math.Ceiling((decimal)ctx.TbProduct.Where(a => a.CategoryId == 1).Count());
            ViewBag.Diamonds = (int)Math.Ceiling((decimal)ctx.TbProduct.Where(a => a.CategoryId == 2).Count());
            ViewBag.Necklace = (int)Math.Ceiling((decimal)ctx.TbProduct.Where(a => a.CategoryId == 3).Count());
            ViewBag.Watches = (int)Math.Ceiling((decimal)ctx.TbProduct.Where(a => a.CategoryId == 4).Count());
            ViewBag.Tiara = (int)Math.Ceiling((decimal)ctx.TbProduct.Where(a => a.CategoryId == 5).Count());
            ViewBag.Earrings = (int)Math.Ceiling((decimal)ctx.TbProduct.Where(a => a.CategoryId == 6).Count());
           //end count
            

            return View(_model);
            // _model.ListCategory = _model.ListAllProducts.GroupBy(a => a.CategoryId).Select(a => a.First()).ToList();

        }
       
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append
                (
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> ProductsByCategory(string categorySlug, int page = 1)
        {
            TbCategory category = await ctx.TbCategory.Where(x => x.Slug == categorySlug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");

            int pageSize = 8;
            var products = ctx.TbProduct.Where(x => x.CategoryId == category.TbCategoryId).Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = page;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)ctx.TbProduct.Where(x => x.CategoryId == category.TbCategoryId).Count() / pageSize);
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.CategorySlug = categorySlug;

            return View(await products.ToListAsync());
        }
        public IActionResult All()
        {

            return View();
        }

       

    }
}
