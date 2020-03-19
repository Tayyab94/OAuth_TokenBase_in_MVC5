using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuthApp.Models
{
    public class ApiUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string UserRole { get; set; }
    }
}