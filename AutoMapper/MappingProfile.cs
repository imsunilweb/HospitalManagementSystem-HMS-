using AutoMapper;
using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.Models;

namespace HospitalManagementSystem_HMS_.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(dest => dest.Appointment_ID, opt => opt.MapFrom(src => src.Appointment_ID))
                .ForMember(dest => dest.Medicine, opt => opt.MapFrom(src => src.Medicine))
                .ForMember(dest => dest.Remark, opt => opt.MapFrom(src => src.Remark))
                .ForMember(dest => dest.Advice, opt => opt.MapFrom(src => src.Advice))
                .ReverseMap()
                .ForMember(dest => dest.Appointment_ID, opt => opt.MapFrom(src => src.Appointment_ID))
                .ForMember(dest => dest.Medicine, opt => opt.MapFrom(src => src.Medicine))
                .ForMember(dest => dest.Remark, opt => opt.MapFrom(src => src.Remark))
                .ForMember(dest => dest.Advice, opt => opt.MapFrom(src => src.Advice));
        }
    }
}
