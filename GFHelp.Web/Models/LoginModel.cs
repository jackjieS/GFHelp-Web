using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GFHelp.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Passsword is required.")]
        public string Password { get; set; }
    }
}
