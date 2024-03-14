using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetShop.Business.Models;
using PetShop.Client.Helpers;
using PetShop.Services.Responses;

namespace PetShop.Client.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        public IndexModel() { }
        public string? Token { get; set; }
        public PaginationResponse<IList<Category>> Paging { get; set; }
        public IList<Category> Categories { get; set; } = default!;
        public async Task OnGetAsync(string token)
        {
            APIHelpers apiHelpers = new APIHelpers();
            Token = token;
            string baseUrl = "http://localhost:5268/api/v1/categories";
            var responseString = await apiHelpers.GetAPI(baseUrl, token);
            Paging = JsonConvert.DeserializeObject <PaginationResponse<IList<Category>>>(responseString);
            if(Paging == null)
            {
                throw new Exception();
            }
            Categories = Paging.responseData.ToList();
            //Categories = new List<Category> { category };
        }
    }
}
