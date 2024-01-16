using AutoMapper;
using Domain.ApiDTO.Complaints;
using Domain.ApiDTO.Demands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DemandCreateDTO, Demand>();
            CreateMap<Demand, DemandCreateDTO>();

            CreateMap<Demand, DemandDTO>();
            CreateMap<DemandDTO, Demand>();


            CreateMap<ComplaintCreateDTO, Complaint>();
            CreateMap<Complaint, ComplaintCreateDTO>();

            CreateMap<Complaint, ComplaintGetDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Text)) 
                .ForMember(dest => dest.Demands, opt => opt.MapFrom(src => src.Demands));

            CreateMap<ComplaintGetDTO, Complaint>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Demands, opt => opt.MapFrom(src => src.Demands));

        }
    }
}
