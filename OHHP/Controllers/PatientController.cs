using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OHHP.Models;

namespace OHHP.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            var patients = GetPatients();
            return View(patients);
        }

        public ActionResult Details(int id)
        {
            // Get patient details that has the specific Id
            var patient = GetPatients().SingleOrDefault(c => c.Id == id);
            // If there no patients registered
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        // Creating a list of patients for testing
        // Temp Code
        private IEnumerable<Patient> GetPatients()
        {
            return new List<Patient>
            {
                new Patient {Id = 1, Name = "Reza Shahbazi"},
                new Patient{Id = 2, Name = "John Doe"}

            };
        }
    }
}