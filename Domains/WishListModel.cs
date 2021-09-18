using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domains
{
    public class WishListModel 
    {
        public WishListModel()
        {
            ListWish = new List<WishListData>();
        }

        public List<WishListData> ListWish { get; set; }

    }
}
