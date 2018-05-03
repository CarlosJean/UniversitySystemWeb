using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name="Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Sede")]
        public int HeadquartersId { get; set; }
        
        public virtual Headquarter Headquarter { get; set; }

        public ICollection<Subject> Subjects { get; set; }


    }
}