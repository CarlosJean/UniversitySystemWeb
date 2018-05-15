using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class Selection
    {
        [Key]
        public int SelectionID { get; set; }

        public int StudentID { get; set; }

        [JsonIgnore]
        public virtual Student Student { get; set; }
        [JsonIgnore]
        public virtual ICollection<SelectionDetail> OrderDetails { get; set; }
    }
}