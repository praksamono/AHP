using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Common;
using DAL.Entities;

namespace Repository
{
    public static class RepositoryModule
    {
       public static void ConfigureRepositoryModule(ContainerBuilder builder)
        {
            // builder.RegisterType<ClassName>().As<InterfaceName>(); for new Classes
            builder.RegisterType<GoalRepository>().As<IGoalRepository>();
            builder.RegisterType<CriteriumRepository>().As<ICriteriumRepository>();
            builder.RegisterType<AlternativeRepository>().As<IAlternativeRepository>();
            builder.RegisterType<CriteriumAlternativeRepository>().As<ICriteriumAlternativeRepository>();

            builder.RegisterType<BaseEntity>().As<IBaseEntity>();

        }
    }
}
