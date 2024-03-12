using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;

namespace PetShop.Client.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorString { get; set; }
        public string Token { get; set; }
        public LoginModel()
        {
            
        }
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPost() 
        {
            using (var httpClient = new  HttpClient())
            {
                LoginDTO loginDTO = new LoginDTO()
                {
                    Username = Username,
                    Password = Password
                };
                var json = JsonConvert.SerializeObject(loginDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5268/api/v1/login", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError(nameof(ErrorString), "Login fail! Wrong email or password!");
                        ErrorString = "Login fail! Wrong email or password!";
                        return Page();
                    }
                    else
                    {
                        Token = apiResponse;
                        return RedirectToPage("/Index", new { Token = apiResponse });
                    }
                }
            }
        }
    }
}
