using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;

namespace Jewellery.Models
{
    public class DetailsViewModel:ReviewsModel
    {
        public TbProduct Product { get; set; }
        public virtual IEnumerable<TbProduct> ListRelated { get;set;}
    }
}
