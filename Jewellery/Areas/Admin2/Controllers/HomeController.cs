using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Jewellery.BL;
using Jewellery.InfraStructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jewellery.Areas.Admin2.Controllers
{
    [Area("Admin2")]
    public class HomeController : Controller
    {
        JewelContext ctx;
        IProductService IProduct;
        public HomeController(JewelContext context,IProductService product)
        {
            ctx = context;
            IProduct = product;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Slider()
        {
            return View(IProduct._slider());
        }

        public IActionResult EditSlider(int? id)
        {
            
            if (id != null)
            {


                return View(IProduct.GetSliderById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> SaveSlider(TbSlider slider, List<IFormFile> Files)
        {

            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Slider", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    slider.SliderImage = ImageName;
                }
            }

            if (slider.TbSliderId == 0)
            {
                IProduct.addslider(slider);

            }
            else
            {
                IProduct.editslider(slider);
            }
            return RedirectToAction("Slider");

        }
        public IActionResult Delete(int id)
        {
            IProduct.DeleteSlider(id);
            return RedirectToAction("Slider");
        }



    }
}
