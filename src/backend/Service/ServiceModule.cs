using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using AHP.Service.Common;

namespace AHP.Service
{
    public static class ServiceModule
    {

        public static void ConfigureServiceModule(ContainerBuilder builder)
        {
            // builder.RegisterType<ClassName>().As<InterfaceName>(); for new Classes
            builder.RegisterType<ServiceAlternative>().As<IServiceAlternative>();
            builder.RegisterType<ServiceCriterium>().As<IServiceCriterium>();
            builder.RegisterType<ServiceCriteriumAlternative>().As<IServiceCriteriumAlternative>();
            builder.RegisterType<ServiceGoal>().As<IServiceGoal>();

        }
    }
}
