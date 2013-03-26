using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExperimentalCMS.Repositories;

namespace ExperimentalCMS.Web.BackEnd.Installers
{
    public class UowInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestyleTransient());
        }
    }
}