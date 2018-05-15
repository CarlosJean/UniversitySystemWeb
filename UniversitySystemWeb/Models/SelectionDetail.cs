using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class SelectionDetail
    {
        [Key]
        public int SelectionDetailID { get; set; }

        public int SelectionID { get; set; }

        public int SubjectID { get; set; }

        public virtual int Selection {get;set;}

        public virtual int Subject{ get; set; }

    }
}