using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;

namespace Jewellery.Models
{
    public class HomePageViewModel
    {

        public IEnumerable<TbSlider> ListSlider { get; set; }
        public IEnumerable<TbProduct> ListAllProducts { get; set; }
        public IEnumerable<TbProduct> ListTopCollection { get; set;}
        public IEnumerable<TbProduct> ListNewProducts { get; set; }
        public IEnumerable<TbProduct> ListBestSeller { get; set; }
        public IEnumerable<TbProduct> ListFeatureProducts { get; set; }
        public IEnumerable<TbProduct> ListCategory { get; set; }
        public IEnumerable<TbProduct> Instagram { get; set; }
    }
}
