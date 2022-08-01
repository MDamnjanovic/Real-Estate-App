using Autofac;
using Interfaces;
using Realty.Data.EntityFramework;
using Realty.Interfaces;
using Realty.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Realty.Data.ContainerConfig
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<RealtyData>().As<IRealtyData>();
            builder.RegisterType<RealtyDataEF>().As<IRealtyData>();
            

            /*builder.RegisterAssemblyTypes(Assembly.Load(nameof(Realty)))
                .Where(t => t.Namespace.Contains(nameof(SQL)))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));*/

            return builder.Build();
        }
    }
}
