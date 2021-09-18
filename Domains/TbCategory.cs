using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
   public class TbCategory
    {
        public int TbCategoryId { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public virtual ICollection<TbProduct> TbProduct { get; set; }
    }
}
