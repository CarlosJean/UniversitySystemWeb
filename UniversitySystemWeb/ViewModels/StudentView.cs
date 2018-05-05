using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystemWeb.Models;

namespace UniversitySystemWeb.ViewModels
{
    public class StudentView
    {
        public Student Student { get; set; }
        public List<Subject> Subjects { get; set; }

    }
}