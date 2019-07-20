using AutoMapper;
using DAL;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<DAL.Goal, Model.Goal>().ReverseMap();
        }
    }
}
