using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jewellery.InfraStructure
{
    public class JewelContext : IdentityDbContext
    {
        public JewelContext(DbContextOptions<JewelContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TbProduct> TbProduct { get; set; }
        public virtual DbSet<ApiView1> ApiView1 { get; set; }
        public virtual DbSet<TbCategory> TbCategory { get; set; }
        public virtual DbSet<TbProductImages> TbProductImages { get; set; }
        public virtual DbSet<TbSlider> TbSlider { get; set; }
        public virtual DbSet<ShopingCart> checkoutdata { get; set; }
        public virtual DbSet<ModelContact1> TbContact { get; set; }
        public virtual DbSet<ReviewsModel> TbReviews { get; set; }
       // public DbSet<Page> Pages { get; set; }
    }
}
