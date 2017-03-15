﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheel.Web.Models
{
    public class CarSparePart
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public SparePart SparePart { get; set; }
    }
}
