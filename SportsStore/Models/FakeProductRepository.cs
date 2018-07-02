using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductRepository /*:  IProductRepository*/
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product {Name = "football", Price = 25 },
            new Product {Name = "surf board", Price = 179 },
            new Product {Name = "running shoes", Price = 95 }
        };
    }
}
