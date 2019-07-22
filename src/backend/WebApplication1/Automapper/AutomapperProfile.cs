﻿using AutoMapper;
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
            CreateMap<DAL.GoalEntity, Model.Common.IGoal>().ReverseMap();
            CreateMap<DAL.CriteriumEntity, Model.Common.ICriterium>().ReverseMap();
            CreateMap<DAL.AlternativeEntity, Model.Common.IAlternative>().ReverseMap();
            CreateMap<DAL.CriteriumAlternativeEntity, Model.Common.ICriteriumAlternative>().ReverseMap();
        }
    }
}
