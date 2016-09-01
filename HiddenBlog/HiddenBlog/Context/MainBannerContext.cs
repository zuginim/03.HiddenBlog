using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HiddenBlog.Models;
using System.Data.Entity;

namespace HiddenBlog.Context
{
    public class MainBannerContext : DbContext
    {
        public DbSet<MainBanner> MainBanners { get; set; }
    }
}