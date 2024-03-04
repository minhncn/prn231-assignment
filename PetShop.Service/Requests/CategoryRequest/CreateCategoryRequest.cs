using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Requests.CategoryRequest
{
    public class CreateCategoryRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
