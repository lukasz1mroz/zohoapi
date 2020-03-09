using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zohotest.Models
{
    public class Product
    {
        public string id { get; set; }
        public Product(string id)
        {
            this.id = id;
        }
    }

}
