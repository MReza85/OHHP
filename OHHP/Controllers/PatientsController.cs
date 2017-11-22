using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OHHP.Models;
using OHHP.ViewModels;

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

        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewModel = new PatientFormViewModel
            {
                MembershipTypes = membershiptypes
            };
            return View("PatientForm",viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken] // Skyddar mot CSRF attack ( Cross-site Request Forgery )
        public ActionResult Save(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PatientFormViewModel(patient)
                {
                    
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("PatientForm",viewModel);
            }
            if (patient.Id == 0)
                _context.Patients.Add(patient);
            else
            {
                var patientInDb = _context.Patients.Single(c => c.Id == patient.Id);

                patientInDb.Name = patient.Name;
                patientInDb.Birthdate = patient.Birthdate;
                patientInDb.Journal = patient.Journal;
                patientInDb.MembershipTypeId = patient.MembershipTypeId;
                patientInDb.IsSubscirbedToNewsletter = patient.IsSubscirbedToNewsletter;

            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Patients");
        }

        //public ActionResult New(Patient patient)
        //{
            
        //        _context.Patients.Add(patient);
        //        _context.SaveChanges();


        //    return RedirectToAction("Index", "Patients");
        //}


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            // Get patient details that has the specific Id
            var patient = _context.Patients.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            // If there no patients registered
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        public ActionResult Edit(int id)
        {
            var patient = _context.Patients.SingleOrDefault(c => c.Id == id);

            if (patient == null)
                return HttpNotFound();
            var viewModel=new PatientFormViewModel(patient)
            {
               
               MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("PatientForm", viewModel);
        }
    }
}