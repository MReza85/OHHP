using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace OHHP.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter patient's name.")] // DataAnnotation for making columns of "Name" not nullable
        [StringLength(255)] //DataAnn.. for setting stringlength max to 255.
        public string Name { get; set; }

        public bool IsSubscirbedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } //Navigation Property, navigation from one type to another, patient -> MembershipType

        [Display(Name = "Membership")]
        [Required(ErrorMessage = "Please select membership.")]
        public byte MembershipTypeId { get; set; } //treats this property as foreign key.

        [Required(ErrorMessage = "Please enter patient's date of birth.")]// DataAnn... for making columns of "Birthdate" not nullable
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        public string Journal { get; set; }
        
    }
}