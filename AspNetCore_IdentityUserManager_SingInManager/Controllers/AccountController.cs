using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_IdentityUserManager_SingInManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_IdentityUserManager_SingInManager.Controllers
{
    public class AccountController : Controller
    {
        // UserManager sınıfı context sınıfına ihtiyaç duymadan kullanıcı ile ilgili işlemleri yapmak için (kullanıcıyı yönetmek iiçn) kullanılır

        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // kayıt ekranını açar...
        public IActionResult Register()
        {
            return View();
        }

        // Kayıt ol actionı => kayıt işlemlierini yapar
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            AppUser user = new AppUser();
            user.Name = model.Name;
            user.Email = model.EmailAdress;
            user.UserName = model.EmailAdress;
            user.SurName = model.SurName;

            // CreateAsync => asyncronous bir metottur. bu yüzden Register meotdunumuzun asyc olması gerekir. 
            var result = await userManager.CreateAsync(user, model.Password); // user bilgileri ve şifreyi createasync metodu veritabanına kaydedecektir. Password tabloda hashli tutulacaktır. Bunun nedeni güvenliktir. Kullanıcların şifreleri veribatabanında açık saklanamazlar. Yakınlarsa büyük problem olur...

            if (result.Succeeded) // işlem başarılıdır....
            {
                return View();
            }
            else
            {
                return View(ModelState);
            }
        }


        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(RegisterViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.EmailAdress);
            var result2 = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            return RedirectToAction("Index", "Home");
        }
    }
}
