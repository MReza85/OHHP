using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using OHHP.Dtos;
using OHHP.Models;

namespace OHHP.Controllers.Api
{
    public class RoomsController : ApiController
    {
        private ApplicationDbContext _context;

         public RoomsController()
         {
             _context = new ApplicationDbContext();
         }
        //Get /api/rooms
        public IEnumerable<RoomDto> GetRooms()
         {
             return _context.Rooms.ToList().Select(Mapper.Map<Room, RoomDto>);
         }

         public IHttpActionResult GetRoom(int id)
         {
             var room = _context.Rooms.SingleOrDefault(c => c.Id == id);
 
             if (room == null)
                 return NotFound();
 
             return Ok(Mapper.Map<Room, RoomDto>(room));
         }
 



         [HttpPost]
         public IHttpActionResult CreateRoom(RoomDto roomDto)
         {
             if (!ModelState.IsValid)
                 return BadRequest();
 
             var room = Mapper.Map<RoomDto, Room>(roomDto);
             _context.Rooms.Add(room);
             _context.SaveChanges();
 
             roomDto.Id = room.Id;
             return Created(new Uri(Request.RequestUri + "/" + room.Id), roomDto);
         }
 



         [HttpPut]
         public IHttpActionResult UpdateRoom(int id, RoomDto roomDto)
         {
             if (!ModelState.IsValid)
                 return BadRequest();
 
             var roomInDb = _context.Rooms.SingleOrDefault(c => c.Id == id);
 
             if (roomInDb == null)
                 return NotFound();
 
             Mapper.Map(roomDto, roomInDb);
 
             _context.SaveChanges();
 
             return Ok();
         }
 



         [HttpDelete]
         public IHttpActionResult DeleteRoom(int id)
         {
             var roomInDb = _context.Rooms.SingleOrDefault(c => c.Id == id);
 
             if (roomInDb == null)
                 return NotFound();
 
             _context.Rooms.Remove(roomInDb);
             _context.SaveChanges();
 
             return Ok();
         }
    }
}
