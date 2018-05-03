using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        public int TeacherId { get; set; }

        public string Name { get; set; }

        public string Schedule { get; set; }
        
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}