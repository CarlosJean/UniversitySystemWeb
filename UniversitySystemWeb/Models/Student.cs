using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class Student
    {

        //public Student()
        //{
        //    Subjects = new HashSet<Subject>();
        //}

        [Key]
        public int StudentID { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name="Apellido")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return Name + " " + LastName; } }

        [Display(Name = "Sede")]
        public int HeadquartersId { get; set; }
        
        public virtual Headquarter Headquarter { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }


    }
}