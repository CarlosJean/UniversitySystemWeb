using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class Subject
    {
        //public Subject()
        //{
        //    Students = new HashSet<Student>();
        //}


        [Key]
        public int SubjectID { get; set; }

        public int TeacherId { get; set; }

        [Display(Name="Materia")]
        public string Name { get; set; }

        [Display(Name = "Horario")]
        public string Schedule { get; set; }
        
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}