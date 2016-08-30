using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HiddenBlog.Models;
using System.Data.Entity;

namespace HiddenBlog.Context
{
    //16.08.30
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}