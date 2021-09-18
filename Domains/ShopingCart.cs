using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public class ShopingCart  : Checkoutdata
    {
        //my cart ViewModel
        public ShopingCart() 
        {
            ListItems = new List<ShopingCartItem>();
        }
        public List<ShopingCartItem> ListItems { get; set; }
        public decimal Total { get; set; }//all products total
        //public string ImageName { get; set; }
        

    }
}
