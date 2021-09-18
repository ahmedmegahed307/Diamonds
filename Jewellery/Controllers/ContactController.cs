using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Jewellery.InfraStructure;
using Jewellery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewellery.Controllers
{
    public class ContactController : Controller
    {
        JewelContext ctx;
        public ContactController(JewelContext context)
        {
            ctx = context;
        }
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(ModelContact1 model)
        {
            ViewBag.first = model.FirstName;
            ctx.TbContact.Add(model);
            ctx.SaveChanges();
            return View("SuccessMessage");
        }
        public IActionResult SuccessMessage()
        {
            
            return View();
        }

    }
}
