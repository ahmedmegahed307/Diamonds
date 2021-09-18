using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class TbProduct
    {

        public int TbProductId { get; set; }
        [Required,MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        public string ProductImageName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public string Slug { get; set; }
        public string Description { get; set;}
        public virtual TbCategory Category { get; set; }
        public virtual ICollection<TbProductImages> FProductImages { get; set;}
    }
}
