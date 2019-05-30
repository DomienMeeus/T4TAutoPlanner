using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace PraktischeProefT4T.Classes
{
   public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Task>();
            builder.RegisterType<Talk>();
            builder.RegisterType<DataLoader>().As<IDataLoader>();
            builder.RegisterType<Planner>().As<IPlanner>();
           

            return builder.Build();
        }
    }
}
