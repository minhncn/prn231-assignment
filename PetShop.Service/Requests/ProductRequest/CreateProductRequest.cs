using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Requests.ProductRequest
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public string Status { get; set; }
    }
}
