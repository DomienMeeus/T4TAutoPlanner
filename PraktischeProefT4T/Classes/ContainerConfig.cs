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
            
            builder.RegisterType<DataLoader>().As<IDataLoader>();
            builder.RegisterType<Planner>().As<IPlanner>();
            builder.RegisterType<RecordBuilder>().As<IRecordBuilder>();
           

            return builder.Build();
        }
    }
}
