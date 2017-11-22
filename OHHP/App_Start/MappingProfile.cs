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
            // Domain to Dto
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<Room, RoomDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            // Dto to Domain

            Mapper.CreateMap<PatientDto, Patient>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<RoomDto, Room>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            // When we call this CreateMap method, Auto Mapper uses reflection to scan these types
            // it finds their properties and maps them based on their names. 
        }
    }
}