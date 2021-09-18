using Domains;
using Jewellery.BL;
using Jewellery.InfraStructure;
using Jewellery.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery.Controllers
{
    public class ReviewsController : Controller
    {
        JewelContext ctx;
        IProductService IProduct;
        public ReviewsController(JewelContext context, IProductService x)
        {
            ctx = context;
            IProduct = x;
        }
        public IActionResult Reviews()
        {
            return View(ctx.TbReviews.ToList());
        }
        [HttpPost]
        public IActionResult ReviewsInfo(ReviewsModel model)
        {
            ViewBag.first = model.FirstName;
            ctx.TbReviews.Add(model);
            ctx.SaveChanges();
            return View("SuccessMessage");
        }
        public IActionResult SuccessMessage()
        {
            return View();
        }
        public IActionResult ReviewsMainPage()
        {
            return View();
        }
    }
}
