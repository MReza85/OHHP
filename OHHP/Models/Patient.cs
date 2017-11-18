using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OHHP.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscirbedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}