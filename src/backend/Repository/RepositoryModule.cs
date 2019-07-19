using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public static class RepositoryModule
    {
       public static void ConfigureRepositoryModule(ContainerBuilder builder)
        {
            // builder.RegisterType<ClassName>().As<InterfaceName>(); for new Classes
        }
    }
}
