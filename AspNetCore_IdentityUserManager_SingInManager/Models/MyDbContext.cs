using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_IdentityUserManager_SingInManager.Models
{
    public class MyDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public MyDbContext(DbContextOptions<MyDbContext> op) : base(op)
        {
        }
    }
}