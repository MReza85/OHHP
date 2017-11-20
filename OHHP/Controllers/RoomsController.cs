using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using OHHP.Models;
using OHHP.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;
using WebGrease.Css;

namespace OHHP.Controllers
{
    public class RoomsController : Controller
    {
        private ApplicationDbContext _context;

        public RoomsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var rooms = _context.Rooms.Include(r => r.RoomType).ToList();
            return View(rooms);
        }


        public ActionResult New()
        {
            //Generate list so that we can put the list in to dropdown box.
            var roomtypes = _context.RoomTypes.ToList();

            //Watch Moshs explaination about this part again
            var viewModel = new RoomFormViewModel
            {
                RoomTypes = roomtypes
            };

            return View("RoomForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            //Get room id
            var room = _context.Rooms.SingleOrDefault(r => r.Id == id);
            //If room id == null
            if (room == null)
                return HttpNotFound();
            //Get room details.
            var viewModel= new RoomFormViewModel
            {
                Room = room,
                RoomTypes = _context.RoomTypes.ToList()
            };
            return View("RoomForm",viewModel);
        }
        
        [HttpPost]
        public ActionResult Save(Room room)
        {
            //If room doesn't exist, add a new room
            if (room.Id == 0)
                _context.Rooms.Add(room);

            //If it does exist, update the columns in database.
            else
            {
                var roomInDb = _context.Rooms.Single(r => r.Id == room.Id);
                roomInDb.Name = room.Name;
                roomInDb.RoomTypeId = room.RoomTypeId;
                roomInDb.NumberOfBeds = room.NumberOfBeds;
            }

                _context.SaveChanges();
           

            return RedirectToAction("Index","Rooms");
        }

     
        public ActionResult Details(int id)
        {
           
            var room = _context.Rooms.Include(r => r.RoomType).SingleOrDefault(r => r.Id == id);
            if (room == null)
                return HttpNotFound();
            return View(room);
        }









        #region IEnumerable local hardcoded
        //private IEnumerable<Room> GetRooms()
        //{
        //    return new List<Room>
        //    {
        //        new Room{Id = 1, Name = "A001"},
        //        new Room{Id = 2, Name = "A002"}
        //    };
        //}
        #endregion


        #region GET: Rooms/Random
        public ActionResult Random()
        {
            var room = new Room() { Name = "A001" };
            var patients = new List<Patient>
            {
                new Patient{Name = "Patient 1"},
                new Patient{Name = "Patient 2"}
            };

            var viewModel = new RandomRoomViewModel
            {
                Room = room,
                Patients = patients
            };

            return View(viewModel);

            #region Different types of Action Results

            /*for more info visit 
             * https://www.udemy.com/the-complete-aspnet-mvc-5-course/learn/v4/t/lecture/4853578?start=0
             */

            // return Content("Hello World!");
            // return HttpNotFound();
            // return  new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page=1, sortBy="name" } );

            #endregion


        }


        #endregion


        #region Rooms/Department/{departmentName}
        [Route("Rooms/department/{dep}")]
        public ActionResult Department(string dep)
        {

            return Content("Room is in department: " + dep);
        }


        #endregion


        #region Old Route Test?
        /*
        public ActionResult Edit(int Id)
        {
            return Content("id=" + Id);
        }
        */
        #endregion


        #region Två olika sätt o göra index null check
        /*
         public ActionResult Index(int? pageIndex, String sortBy)
         {
             if (!pageIndex.HasValue)
                 pageIndex = 1;
             if (String.IsNullOrWhiteSpace(sortBy))
                 sortBy = "Name";
             return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

         }
         */
        /*
          public ActionResult Index(int pageIndex = 1, string sortBy = "Name")
        {
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        */


        #endregion


    }
}