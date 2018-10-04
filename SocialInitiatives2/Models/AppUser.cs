using Microsoft.AspNetCore.Identity;
using SocialInitiatives2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialInitiatives2.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser(RegisterModel registerModel) : base()
        {
            UserName = registerModel.Name;
            Name = registerModel.Name;
            Email = registerModel.Email;
        }
        public AppUser() : base() { }
        public string Name { get; set; }
    }
}
