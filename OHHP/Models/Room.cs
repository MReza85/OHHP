using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;

namespace OHHP.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
       
        [Required]
        public RoomType RoomType { get; set; }
        public byte RoomTypeId { get; set; }

        [Range(1,5)]
        [Required]
        public byte NumberOfBeds { get; set; }

    }


}