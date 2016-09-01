using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HiddenBlog.Models
{
    public class MainBanner
    {
        [Key]
        public string Name { get; set; }
        public string Path { get; set; }
    }
}