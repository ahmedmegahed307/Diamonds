using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
   public class TbProductImages
    {
        public int TbProductImagesId { get; set; }
        [Required]
        public string  ImageName { get; set; }
        public int ProductId { get; set; }
        public virtual TbProduct Product { get; set; }

    }
}
