using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using AHP.Service.Common;

namespace AHP.Service
{
    public static class ModuleService
    {
      public static void ConfigureServiceModule(ContainerBuilder builder)
        {
            // builder.RegisterType<ClassName>().As<InterfaceName>(); for new Classes
            builder.RegisterType<AlternativeService>().As<IAlternativeService>();
            builder.RegisterType<CriteriumService>().As<ICriteriumService>();
            builder.RegisterType<CriteriumAlternativeService>().As<ICriteriumAlternativeService>();
            builder.RegisterType<GoalService>().As<IGoalService>();
            builder.RegisterType<MainService>().As<IMainService>();
        }
    }
}
