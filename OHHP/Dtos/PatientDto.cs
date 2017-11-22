using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OHHP.Models;

namespace OHHP.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter patient's name.")] // DataAnnotation for making columns of "Name" not nullable
        [StringLength(255)] //DataAnn.. for setting stringlength max to 255.
        public string Name { get; set; }

        public bool IsSubscirbedToNewsletter { get; set; }


        
        [Required(ErrorMessage = "Please select membership.")]
        public byte MembershipTypeId { get; set; } //treats this property as foreign key.

        [Required(ErrorMessage = "Please enter patient's date of birth.")]// DataAnn... for making columns of "Birthdate" not nullable
        public DateTime Birthdate { get; set; }
        public string Journal { get; set; }
    }
}