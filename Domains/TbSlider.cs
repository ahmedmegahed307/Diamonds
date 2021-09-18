using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class TbSlider
    {
        public int TbSliderId { get; set; }
       
        public string Title { get; set; }
        [Required]
        public string SliderImage { get; set; }
        
        public string Description { get; set; }
    }
}
