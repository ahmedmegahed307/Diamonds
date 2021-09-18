using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Jewellery.InfraStructure;
using Jewellery.Models;

namespace Jewellery.BL
{
    public interface ICategorySerivce
    {

        List<TbCategory> GetAll();
       TbCategory GetById(int id);
        bool addcategory(TbCategory category);
        bool editcategory(TbCategory category);

        bool Delete(string name);
      // bool editcategory(TbCategory category);
    }
    public class ClsCategory : ICategorySerivce
    {
        JewelContext ctx;
        public ClsCategory(JewelContext context)
        {
            ctx = context;
           
        }
        public List<TbCategory> GetAll()
        {
            var item = ctx.TbCategory.ToList();
            return item;
        }
        public TbCategory GetById(int id)
        {
            var item = ctx.TbCategory.Where(a => a.TbCategoryId == id).FirstOrDefault();
            return item;
        }
        public bool addcategory(TbCategory category)
        {
            ctx.TbCategory.Add(category);
            ctx.SaveChanges();
            return true;
        }
        public bool editcategory(TbCategory category)
        {


            //var result = ctx.TbCategory.Where(a => a.CategoryName == name).FirstOrDefault();
            //result.CategoryName = name;
            //ctx.SaveChanges();
            //return true;
            ctx.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            ctx.SaveChanges();
            return true;
        }
        
        //public bool editcategory(TbCategory category)
        //{
        //    ctx.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    ctx.SaveChanges();
        //    return true;
            
        //}
        public bool Delete(string name)
        {
            var result = ctx.TbCategory.Where(a => a.CategoryName == name).FirstOrDefault();
            ctx.TbCategory.Remove(result);
            ctx.SaveChanges();
            return true;
        }
    }
}
