using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class ModelModule
    {
        public static void ConfigureModelModule(ContainerBuilder builder)
        {
            // builder.RegisterType<ClassName>().As<InterfaceName>(); for new Classes
        }
    }
}
