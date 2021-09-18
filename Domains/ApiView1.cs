using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class ApiView1

    {
        [Key]
        public int TbProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageName { get; set; }
        public int TbCategoryId { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
