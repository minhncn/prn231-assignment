using PetShop.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Intefaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
