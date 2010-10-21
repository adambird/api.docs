using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data.Repository;
using Ninject.Modules;

namespace api.docs.Dependencies
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IResourceRepository>().To<ResourceRepository>();
            Bind<IResourceDocRepository>().To<ResourceDocRepository>();
        }
    }
}