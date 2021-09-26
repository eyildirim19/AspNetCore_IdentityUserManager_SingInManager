using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_IdentityUserManager_SingInManager.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        [Required]
        public string EmailAdress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}