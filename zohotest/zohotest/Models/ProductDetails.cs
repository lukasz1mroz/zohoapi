using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace zohotest.Models
{
    public class ProductDetails
    {
        public JObject product;
        public long quantity;
        public string book;
        public string product_description;
    }
}
