using System.Web.Optimization;

namespace ExperimentalCMS.Web.BackEnd.App_Start
{
    public class BundleConfig
    {
                // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.9.1.js",
                "~/Scripts/jquery-ui-1.10.3.custom.js",
                "~/Scripts/jQuery.tmpl.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/Application/function.core.js",
                "~/Scripts/jquery.globalize/globalize.js",
                "~/Scripts/jquery.globalize/cultures/globalize.culture.en-GB.js",
                "~/Scripts/knockout-2.3.0.js"
                ));

      
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*",
                "~/Content/ckeditor/ckeditor.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/jquery-ui-1.10.3.custom.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/EditPlace").Include(
                "~/Scripts/Application/function.customformerrors.js",
                "~/Scripts/Application/function.associatewithplace.js",
                "~/Scripts/Application/function.associatewitharticle.js",
                "~/Scripts/Application/function.associatewithpictures.js",
                "~/Scripts/Application/KoModels/ko.photo.model.js",
                "~/Scripts/Application/KoViewModels/ko.selectpictures.viewmodel.js"
                ));
        }
    }
}

/*
		private static BundleCollection UserIndexJavaScript(this BundleCollection bundles)
		{
			var usersBundle = new ScriptBundle("~/Bundles/UserListing") {Orderer = new AsIsBundleOrderer()}
				.Include("~/Scripts/Application/BundleConfigs/UserListing.js",
				         "~/Scripts/Application/functions.clipboard.js",
				         "~/Scripts/Application/functions.customForms.js",
				         "~/Scripts/Application/functions.tableActions.js",
				         "~/Scripts/Application/functions.bulkActions.js",
				         "~/Scripts/Application/functions.ajaxPageRefresh.js",
				         "~/Scripts/Application/users-list-filter.js",
				         "~/Scripts/Application/functions.quickSearch.js",
				         "~/Scripts/Application/functions.simSettings.js",
				         "~/Scripts/Application/functions.bulkSimSettingsOverlay.js",
				         "~/Scripts/Application/functions.associateWithSimOverlay.js",
				         "~/Scripts/Application/functions.deleteUsersOverlay.js",
                         "~/Scripts/knockout-{version}.js",
                         "~/Scripts/Application/ko.userlist.js",
                         "~/Scripts/Application/functions.intervalController.js"
                         );

			bundles.Add(usersBundle);
			return bundles;
		}

		private static BundleCollection GroupIndexJavaScript(this BundleCollection bundles)
		{
			var groupsBundle = new ScriptBundle("~/Bundles/GroupListing") {Orderer = new AsIsBundleOrderer()}
				.Include("~/Scripts/Application/BundleConfigs/GroupListing.js",
				         "~/Scripts/Application/functions.clipboard.js",
				         "~/Scripts/Application/functions.customForms.js",
				         "~/Scripts/Application/functions.tableActions.js",
				         "~/Scripts/Application/functions.bulkActions.js",
				         "~/Scripts/Application/functions.ajaxPageRefresh.js",
				         "~/Scripts/Application/groups-list-filter.js");

			bundles.Add(groupsBundle);
			return bundles;
		}
*/