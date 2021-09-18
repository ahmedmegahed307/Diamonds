using Domains;
using Jewellery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery.InfraStructure
{
    public class CategoriesViewComponent : ViewComponent
    {
        JewelContext ctx;
        public CategoriesViewComponent(JewelContext context)
        {
            ctx = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        private Task<List<TbCategory>> GetCategoriesAsync()
        {
            return ctx.TbCategory.ToListAsync();
        }
    }
}
