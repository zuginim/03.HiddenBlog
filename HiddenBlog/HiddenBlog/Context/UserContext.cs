﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HiddenBlog.Models;
using System.Data.Entity;

namespace HiddenBlog.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}