using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Domain.Managers;
using ExperimentalCMS.Web.FrontEnd.Utility;

namespace ExperimentalCMS.Web.FrontEnd.Installers
{
    public class ManagersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var flickrApiKey = System.Configuration.ConfigurationManager.AppSettings[Constants.AppSettingKeys.FlickrApiKey].ToString();
            var flickrApiSecret = System.Configuration.ConfigurationManager.AppSettings[Constants.AppSettingKeys.FlickrSecret].ToString();

            container.Register(Component.For<IAdminManager>().ImplementedBy<AdminManager>().LifestyleTransient());
            container.Register(Component.For<IArticleManager>().ImplementedBy<ArticleManager>().LifestyleTransient());
            container.Register(Component.For<IPlaceManager>().ImplementedBy<PlaceManager>().LifestyleTransient());
            container.Register(Component.For<IPhotoManager>().ImplementedBy<PhotoManager>().DependsOn(new { apiKey = flickrApiKey, secret = flickrApiSecret }).LifestyleTransient());
        }
    }
}