using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//16.08.30
using System.ComponentModel.DataAnnotations;

namespace HiddenBlog.Models
{
    //16.08.30
    public class User
    {
        [Required(ErrorMessage = "enter your ID")]
        public string ID { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "enter your Password")]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}