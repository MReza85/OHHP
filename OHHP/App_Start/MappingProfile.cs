using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OHHP.Dtos;
using OHHP.Models;

namespace OHHP.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Generic method < Source, Target > 
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<PatientDto, Patient>();
            // When we call this CreateMap method, Auto Mapper uses reflection to scan these types
            // it finds their properties and maps them based on their names. 
        }
    }
}