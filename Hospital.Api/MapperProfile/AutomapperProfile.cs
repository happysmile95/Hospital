using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PatientDto, Patient>();
            CreateMap<Patient, PatientEditModel>();
            CreateMap<Patient, PatientViewModel>()
                .ForMember(dest => dest.SiteNumber, p => p.MapFrom(e => e.Site == null ? null : e.Site.Number.ToString()));
            CreateMap<PatientEditModel, Patient>();

            CreateMap<DoctorDto, Doctor>();
            CreateMap<Doctor, DoctorEditModel>();
            CreateMap<Doctor, DoctorViewModel>()
                .ForMember(dest => dest.Specialization, p => p.MapFrom(e => e.Specialization == null ? null : e.Specialization.Name))
                .ForMember(dest => dest.ParlorNumber, p => p.MapFrom(e => e.Parlor.Number))
                .ForMember(dest => dest.SiteNumber, p => p.MapFrom(e => e.Site == null ? null : (int?)e.Site.Number));
            CreateMap<DoctorEditModel, Doctor>();
        }
    }
}
