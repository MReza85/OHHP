using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using OHHP.Models;

namespace OHHP.ViewModels
{
    public class RandomRoomViewModel
    {
        public Room Room { get; set; }
        public List<Patient> Patients { get; set; }

    }
}