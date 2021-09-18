using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Jewellery.BL;
using Jewellery.InfraStructure;
using Jewellery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace Jewellery.Controllers
{
    public class DetailsController : Controller
    {
        JewelContext ctx;
        IProductService IProduct;
        public DetailsController(JewelContext context,IProductService x)
        {
            ctx = context;
            IProduct = x;
        }
        public IActionResult Index(int id)
        {
            DetailsViewModel model = new DetailsViewModel();
            model.Product = IProduct.ProductWithImage(id);
            model.ListRelated = IProduct.Related(model.Product.ProductPrice).ToList();
            return View(model);
        }


        
//          div.ajaxbg {
//    background: rgba(255,255,255, .8);
//    position: absolute;
//    top: 0;
//    left: 0;
//    width: 100%;
//    height: 100%;
//    transition-duration: 10s;
//    z-index: 1;
//}

//    div.ajaxbg > img {
//        position: absolute;
//        top: 30%;
//        left: 50%;
       
//         transform: translateX(-50%);
//        z-index: 2;
//    }

//div.ajaxbg > p {
//        position: absolute;
//        top: 50px;
//        z-index: 2;
//    }

        
        

    }
}
