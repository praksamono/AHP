using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryProfile : Profile
    {
       public RepositoryProfile()
        {
            CreateMap<DAL.GoalEntity, Model.Common.IGoal>().ReverseMap();
            CreateMap<DAL.CriteriumEntity, Model.Common.ICriterium>().ReverseMap();
            CreateMap<DAL.AlternativeEntity, Model.Common.IAlternative>().ReverseMap();
            CreateMap<DAL.CriteriumAlternativeEntity, Model.Common.ICriteriumAlternative>().ReverseMap();
        }
    }
}
