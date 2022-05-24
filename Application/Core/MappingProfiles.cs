using Application.DailyCases;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DailyCasesReport, AvailableDatesDTO>()
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date));
        }
    }
}
