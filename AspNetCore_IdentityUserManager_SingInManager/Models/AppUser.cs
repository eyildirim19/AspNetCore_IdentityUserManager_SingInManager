using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_IdentityUserManager_SingInManager.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }

    public class AppRole : IdentityRole<int>
    {
    }
}
