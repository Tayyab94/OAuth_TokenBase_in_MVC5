using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OuthApp.Models
{
    public class OauthContext:DbContext
    {
        public OauthContext():base("dbConnectionString")
        {

        }

        public DbSet<ApiUser> ApiUsers { get; set; }
    }
}