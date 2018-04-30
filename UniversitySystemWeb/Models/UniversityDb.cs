using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class UniversityDb : DbContext
    {
        public System.Data.Entity.DbSet<UniversitySystemWeb.Models.Headquarter> Headquarters { get; set; }

        public System.Data.Entity.DbSet<UniversitySystemWeb.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<UniversitySystemWeb.Models.Subject> Subjects { get; set; }
    }
}