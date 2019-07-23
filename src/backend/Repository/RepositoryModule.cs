﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Common;

namespace Repository
{
    public static class RepositoryModule
    {
       public static void ConfigureRepositoryModule(ContainerBuilder builder)
        {
            // builder.RegisterType<ClassName>().As<InterfaceName>(); for new Classes
            builder.RegisterType<GoalRepository>().As<IGoalRepository>();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>();

        }
    }
}
