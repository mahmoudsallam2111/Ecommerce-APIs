﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class ReadorderDto
    {
        public  string address { get; set; }
        public DateTime createdate { get; set; }
        public decimal TotalPrice { get; set; }


    }
}
