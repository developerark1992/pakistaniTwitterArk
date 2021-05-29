using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace PakistaniTwitter.Models
{
    public class PersonVM
    {
        [Required]
        public string UserId { get; set; }
        [DisplayName("Password")]
        [Required]
        public string Pwd { get; set; }
        [Required]
        [DisplayName("Fullname")]
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Joined { get; set; }
        public bool Active { get; set; }
    }
}