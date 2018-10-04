using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialInitiatives2.Models.ViewModels
{
    public class InitiativeModel
    {
        [Required]
        public string returnUrl { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Field { get; set; }

        [Required]
        public string work { get; set; }

        [Required]
        public string OwnerName { get; set; }

        [Required]
        public string InitiativeAddress { get; set; }

        [Required]
        public IFormFile imageUpload { get; set; } 
    }
}
