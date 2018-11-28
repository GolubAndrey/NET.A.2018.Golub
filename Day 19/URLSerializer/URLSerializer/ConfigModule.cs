using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace URLSerializer
{
    public class ConfigModule:NinjectModule
    {
        #region Ninject Overloads
        /// <summary>
        /// Method Load ninject overload
        /// </summary>
        public override void Load()
        {
            Bind<IValidator<string, URL>>().To<URLValidator>();
            Bind<IConverter<string,URL>>().To<URLParser>();
            Bind<ISerializer<URL>>().To<URLSerializer>();
            Bind<IRepository<string>>().To<URLFileReader>().WithConstructorArgument("way", @"E:\EPAM\NET.A.2018.Golub\Day 19\URLSerializer\URLs.txt");
        }
        #endregion
    }
}
