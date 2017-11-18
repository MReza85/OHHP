using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OHHP.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public bool IsMember { get; set; }
        public byte DiscountRate { get; set; }
    }
}