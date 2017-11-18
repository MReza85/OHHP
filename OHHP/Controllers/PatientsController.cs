using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OHHP.Models;

namespace OHHP.Controllers
{
    public class PatientsController : Controller
    {
        //Needed to access the database
        private ApplicationDbContext _context;

        //Constructor to intilize an instans of the connection?
        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }
        //Db contex is a disposable object so to dispose it we need this method
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        public ActionResult Index()
        {
            var patients = _context.Patients.ToList();
            return View(patients);
        }

        public ActionResult Details(int id)
        {
            // Get patient details that has the specific Id
            var patient = _context.Patients.SingleOrDefault(c => c.Id == id);
            // If there no patients registered
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

    }
}