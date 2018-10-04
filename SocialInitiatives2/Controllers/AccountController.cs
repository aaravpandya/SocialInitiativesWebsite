using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialInitiatives2.Models;
using SocialInitiatives2.Models.ViewModels;

namespace SocialInitiatives2.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private AppIdentityDbContext AppIdentityDbContext;
        private IMapper _mapper;
        public AccountController(UserManager<AppUser> userMgr,
                SignInManager<AppUser> signInMgr, AppIdentityDbContext dbContext,IMapper mapper)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            AppIdentityDbContext = dbContext;
            _mapper = mapper;
        }
       
        public async Task<IActionResult> Register (RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<AppUser>(new AppUser(registerModel));
            IdentityResult result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
                return new BadRequestObjectResult(result.Errors);
            //await AppIdentityDbContext.AppUsers.AddAsync(user);
            //await AppIdentityDbContext.SaveChangesAsync();
            return Redirect(registerModel?.ReturnUrl ?? "/Index/Home");
        }

        public async Task<IActionResult> Login (LoginModel login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await userManager.FindByEmailAsync(login.Email);
            if(user != null)
            {
                await signInManager.SignOutAsync();
                if((await signInManager.PasswordSignInAsync(user, login.Password, false, false)).Succeeded)
                {
                    return Redirect(login?.ReturnUrl ?? "/Index/Home");
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return BadRequest(ModelState);
        }

        public async Task<IActionResult> LogOut ()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await signInManager.SignOutAsync();
            return RedirectToAction("Home", "Index");
        }

    }

}