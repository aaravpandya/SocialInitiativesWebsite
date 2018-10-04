using SocialInitiatives2.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialInitiatives2.Models
{
    public class Initiative
    {
        public int InitiativeId { get; set; }

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
        public Image Image { get; set; }

    }
}
