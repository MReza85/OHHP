using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OHHP.Models;

namespace OHHP.ViewModels
{
    public class PatientFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter patient's name.")] // DataAnnotation for making columns of "Name" not nullable
        [StringLength(255)] //DataAnn.. for setting stringlength max to 255.
        public string Name { get; set; }

        public bool IsSubscirbedToNewsletter { get; set; }


        [Display(Name = "Membership")]
        [Required(ErrorMessage = "Please select membership.")]
        public byte? MembershipTypeId { get; set; } //treats this property as foreign key.

        [Required(ErrorMessage = "Please enter patient's date of birth.")]// DataAnn... for making columns of "Birthdate" not nullable
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }

        public string Journal { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Patient" : "New Patient";
            }
        }

        public PatientFormViewModel()
        {
            Id = 0;
        }

        public PatientFormViewModel(Patient patient)
        {
            Id = patient.Id;
            Name = patient.Name;
            Birthdate = patient.Birthdate;
            Journal = patient.Journal;
            MembershipTypeId = patient.MembershipTypeId;
            IsSubscirbedToNewsletter = patient.IsSubscirbedToNewsletter;
        }
    }
}