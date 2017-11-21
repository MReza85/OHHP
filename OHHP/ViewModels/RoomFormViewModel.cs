using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using OHHP.Models;

namespace OHHP.ViewModels
{
    public class RoomFormViewModel
    {
        public IEnumerable<RoomType> RoomTypes { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter room name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Room type")]
        [Required(ErrorMessage = "Please choose room type.")]
        public byte? RoomTypeId { get; set; }

        [Range(1, 5, ErrorMessage = "Room requires between 1 to 5 beds")]
        [Required(ErrorMessage = "Please enter amount of beds in the room.")]
        [Display(Name = "Number of patient beds")]
        public byte? NumberOfBeds { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";

        public RoomFormViewModel()
        {
            Id = 0;
        }

        public RoomFormViewModel(Room room)
        {
            Id = room.Id;
            Name = room.Name;
            RoomTypeId = room.RoomTypeId;
            NumberOfBeds = room.NumberOfBeds;
        }
    }
}