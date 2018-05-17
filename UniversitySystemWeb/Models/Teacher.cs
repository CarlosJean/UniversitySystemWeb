using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Profesor")]
        [NotMapped]
        public string FullName { get { return Name + " " + LastName; } }

        public virtual ICollection<Subject> Subjects { get; set; }

    }
}