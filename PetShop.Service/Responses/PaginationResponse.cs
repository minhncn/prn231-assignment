using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Responses
{
    public class PaginationResponse<T>
    {
        public PaginationResponse(T responseData)
        {
            this.responseData = responseData;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public T responseData { get; set; }
    }
}
