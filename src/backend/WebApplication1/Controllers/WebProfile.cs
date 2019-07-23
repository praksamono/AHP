using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI
{
    public class WebAPIProfile : Profile
    {
       public WebAPIProfile()
        {
            CreateMap<GoalDTO, Model.Common.IGoal>().ReverseMap();
            CreateMap<CriterionDTO, Model.Common.ICriterium>().ReverseMap();
            CreateMap<AlternativeDTO, Model.Common.IAlternative>().ReverseMap();
            // CreateMap<DAL.CriteriumAlternativeEntity, Model.Common.ICriteriumAlternative>().ReverseMap();
        }
    }
}