using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using OHHP.Dtos;
using OHHP.Models;

namespace OHHP.Controllers.Api
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/patients
        public IHttpActionResult GetPatients()
        {
            var patientDtos =_context.Patients.
                Include(p => p.MembershipType)
                .ToList()
                .Select(Mapper.Map<Patient, PatientDto>);

            return Ok(patientDtos);
            
        }

        //Get /api/patient/1

        public IHttpActionResult GetPatient(int id)
        {
            var patient = _context.Patients.SingleOrDefault(c => c.Id == id);

            if (patient == null)
                return NotFound();
            return Ok( Mapper.Map<Patient, PatientDto>(patient));
        }

        //Post /api/patients
        [HttpPost]
        public IHttpActionResult CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patient = Mapper.Map<PatientDto, Patient>(patientDto);
            _context.Patients.Add(patient);
            _context.SaveChanges();

            patientDto.Id = patient.Id;

            return Created(new Uri(Request.RequestUri + "/"+ patient.Id), patientDto);
        }

        //Put /api/patient/1
        [HttpPut]
        public IHttpActionResult UpdatePatient(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            //get patient from db and check if it exist or not
            var patientInDb = _context.Patients.SingleOrDefault(c => c.Id == id);
           

            if (patientInDb == null)
                return NotFound();
           
            Mapper.Map(patientDto, patientInDb);
            

            _context.SaveChanges();

            return Ok();

        }

        //DELETE /api/patient/1
        [HttpDelete]
        public IHttpActionResult DeletePatient(int id)
        {
            //get patient from db and check if it exist or not
            var patientInDb = _context.Patients.SingleOrDefault(c => c.Id == id);

            if (patientInDb == null)
                return NotFound();

            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();

            return Ok();

        }

    }
}
