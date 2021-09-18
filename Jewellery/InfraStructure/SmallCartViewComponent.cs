using Jewellery.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Jewellery.InfraStructure;

namespace Jewellery.Infrastructure
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ShopingCart cart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            SmallCartViewModel model;
            if(cart==null||cart.ListItems.Count==0)
            {
                model = null;
            }
            else
            {
                model = new SmallCartViewModel
                {
                    NumberOfItems = cart.ListItems.Sum(x => x.Qty),
                    TotalAmount = cart.ListItems.Sum(x => x.Qty * x.Price),
                   
                   
                };
            }
            return View(model);
            


        }
    }
}
