using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OHHP.Models;

namespace OHHP.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter room name.")]
        [StringLength(255)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please choose room type.")]
        public byte RoomTypeId { get; set; }

        public RoomTypeDto RoomType { get; set; }

        [Range(1, 5, ErrorMessage = "Room requires between 1 to 5 beds")]
        [Required(ErrorMessage = "Please enter amount of beds in the room.")]
        public byte NumberOfBeds { get; set; }
    }
}