using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystemWeb.Models
{
    public class Headquarter
    {
        [Key]
        [Display(Name = "Sede")]
        public int HeadquartersId { get; set; }

        [Display(Name = "Nombre de sede")]
        [Required(ErrorMessage ="Debe llenar el campo {0}")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe llenar el campo {0}")]
        public string Address { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public long Phone { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}