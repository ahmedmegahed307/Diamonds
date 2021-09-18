using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Jewellery.InfraStructure;
using Jewellery.Models;
using Microsoft.EntityFrameworkCore;

namespace Jewellery.BL
{
    public interface IProductService
    {

        List<TbProduct> GetAll();
        List<TbProductImages> GetAllPhotos();
        List<ApiView1> GetAll2();
        TbProduct GetById(int id);
        TbProductImages GetPhotoById(int id);
        TbSlider GetSliderById(int id);
        bool additem(TbProduct product);
        bool Edit(TbProduct product);
        bool Delete(int id);
        bool Deletephoto(int id);
        List<TbSlider> _slider();
        TbProduct ProductWithImage(int id);
        List<TbProduct> Related(decimal price);
        bool additem(TbProductImages image);
        bool editslider(TbSlider slider);
        bool addslider(TbSlider slider);
        bool DeleteSlider(int id);

    }
    public class ClsProduct : IProductService
    {
        JewelContext ctx;
        public ClsProduct(JewelContext context)
        {
            ctx = context;
        }

        public bool additem(TbProduct product)
        {
            ctx.TbProduct.Add(product);
            ctx.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var result = ctx.TbProduct.Where(a => a.TbProductId == id).FirstOrDefault();
            ctx.TbProduct.Remove(result);
            ctx.SaveChanges();
            return true;
        }
        public bool Deletephoto(int id)
        {
            var result = ctx.TbProductImages.Where(a => a.ProductId == id).FirstOrDefault();
            ctx.TbProductImages.Remove(result);
            ctx.SaveChanges();
            return true;
        }

        public bool Edit(TbProduct product)
        {
            ctx.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }

        public List<TbProduct> GetAll()
        {
            List<TbProduct> product = ctx.TbProduct.Include(a => a.Category).ToList();
            return product;
        }
        public List<TbProductImages> GetAllPhotos()
        {
            List<TbProductImages> product = ctx.TbProductImages.ToList();
            return product;
        }

        public TbProduct GetById(int id)
        {
            var item = ctx.TbProduct.Where(a => a.TbProductId == id).FirstOrDefault();
            return item;
        }
        public TbProductImages GetPhotoById(int id)
        {
            var item = ctx.TbProductImages.Where(a => a.ProductId == id).FirstOrDefault();
            return item;
        }
        public TbSlider GetSliderById(int id)
        {
            var item = ctx.TbSlider.Where(a => a.TbSliderId == id).FirstOrDefault();
            return item;
        }
        public bool additem(TbProductImages image)
        {
            ctx.TbProductImages.Add(image);
            ctx.SaveChanges();
            return true;
        }
        public bool addslider(TbSlider slider)
        {
            ctx.TbSlider.Add(slider);
            ctx.SaveChanges();
            return true;
        }
        public bool DeleteSlider(int id)
        {
            var result = ctx.TbSlider.Where(a => a.TbSliderId == id).FirstOrDefault();
            ctx.TbSlider.Remove(result);
            ctx.SaveChanges();
            return true;
        }

        public bool editslider(TbSlider slider)
        {
            ctx.Entry(slider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }

        //................HomePage...................//
        public List<TbSlider> _slider()
        {
            var item = ctx.TbSlider.ToList();
            return item;
        }
        //........DetailsPage...............//
        public TbProduct ProductWithImage(int id)
        {

            var result = ctx.TbProduct.Include(a => a.FProductImages).Where(a => a.TbProductId == id).FirstOrDefault();
            return result;
        }

        public List<TbProduct> Related(decimal price)
        {
            decimal start =price- 4000;
            decimal end = price + 5000;
            var item = ctx.TbProduct.Where(a=>a.ProductPrice >= start && a.ProductPrice <= end).ToList();
            return item;
        }

        public List<ApiView1> GetAll2()
        {
            List<ApiView1> product = ctx.ApiView1.ToList();
            return product;
        }

       
    }
}
