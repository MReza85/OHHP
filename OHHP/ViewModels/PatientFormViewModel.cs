using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OHHP.Models;

namespace OHHP.ViewModels
{
    public class PatientFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Patient Patient { get; set; }
    }
}