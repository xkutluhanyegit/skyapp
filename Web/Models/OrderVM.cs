using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Web.Models
{
    public class OrderVM:Order
    {
        public IFormFile? photo { get; set; }
    }
}