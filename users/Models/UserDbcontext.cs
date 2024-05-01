using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace users.Models
{
    public class UserDbcontext:DbContext
    {
        public UserDbcontext() : base("UserDatabase") { }

        public DbSet<Users> Users { get; set; }

    }
}