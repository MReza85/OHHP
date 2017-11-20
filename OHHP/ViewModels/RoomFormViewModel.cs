using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using OHHP.Models;

namespace OHHP.ViewModels
{
    public class RoomFormViewModel
    {
        public IEnumerable<RoomType> RoomTypes { get; set; }
        public Room Room { get; set; }

        public string Title
        {
            get
            {
                if (Room != null && Room.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}