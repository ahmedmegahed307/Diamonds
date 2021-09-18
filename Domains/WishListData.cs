using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class WishListData 
    {
        [Key]
        public int  WishListDataId { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        
    }
}
