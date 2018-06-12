using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GFHelp.Web.Models
{
    public class gameAccountModel
    {


        //public int Id { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Key]
        [Required(ErrorMessage = "Accountid is required.")]
        public string Accountid { get; set; }

        public string Password { get; set; }

        public string Platform { get; set; }

        public string Channelid { get; set; }

        public string WorldId { get; set; }
    }
}
